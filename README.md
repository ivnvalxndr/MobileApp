# Weather Sensor App 🌦️ 
Разработано студентами группы РИС-22-1БЗУ Ивановым Александром совместно с Даниилом Меркушевым и Даниилом Галушиным

Мобильное приложение на C# (.NET MAUI / Xamarin.Forms), которое подключается к HTTP-серверу и отображает данные с погодных датчиков (Raspberry) в реальном времени:

- 🌡️ Температура
- 💧 Влажность
- ☀️ Осадки (визуальное представление — солнце/дождь)
- ⏰ Время последнего обновления

---

## 📱 Скриншоты

> ![image](https://github.com/user-attachments/assets/1a1ffb39-c687-4269-a2fb-4c50b9631b27)
> ![image](https://github.com/user-attachments/assets/64ac23bf-bf20-4ca0-81ba-794d4bb52d54)



---

## ⚙️ Функциональность

- Загружает данные с удалённого сервера `http://85.209.229.161:5001/sensor` в формате JSON.
- Асинхронно обрабатывает ответ и отображает:
  - Температуру с °C
  - Влажность в %
  - Осадки в виде картинки (`sunny.png` / `rainy.png`)
- Отображает время последнего обновления в формате `HH:mm` или `19 мая 2025, 21:43`.

---

Формат данных от сервера:
{
  "Температура": 23,
  "Влажность": 57.4,
  "Осадки": "Сухо",
  "Время": "2025-05-19 22:37:05"
}
