from flask import Flask, Response
import json
import time
import board
import adafruit_dht
import digitalio

app = Flask(__name__)

dhtDevice = adafruit_dht.DHT22(board.D4)
rain_sensor = digitalio.DigitalInOut(board.D17)
rain_sensor.direction = digitalio.Direction.INPUT

@app.route("/sensor", methods=["GET"])
def get_sensor_data():
    try:
        temperature = dhtDevice.temperature
        humidity = dhtDevice.humidity
        rain_state = "Дождь" if not rain_sensor.value else "Сухо"
        data = {
            "Температура": round(temperature, 1),
            "Влажность": round(humidity, 1),
            "Осадки": rain_state,
            "Время": time.strftime("%Y-%m-%d %H:%M:%S")
        }
        return Response(
            response = json.dumps(data, ensure_ascii=False),
            status=200,
            mimetype="application/json"
        )
    except Exception as e:
        return Response(
            response=json.dumps({"Ошибка": str(e)}, ensure_ascii=False),
            status=500,
            mimetype="application/json"
        )

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)
