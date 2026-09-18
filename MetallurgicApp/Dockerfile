# Используем легкий образ Node.js
FROM node:24-alpine

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем package.json и package-lock.json (для кеширования npm install)
COPY package*.json ./

# Устанавливаем зависимости
RUN npm install

# Копируем весь исходный код
COPY . .

# Открываем порт (замените 8000 на ваш, если используете другой)
EXPOSE 8000

# Команда для запуска. 
# Если используете Vite: npm run dev -- --host
# Если используете Create React App: npm start
# (Уточните ниже, если команда другая)
CMD ["npm", "start"]