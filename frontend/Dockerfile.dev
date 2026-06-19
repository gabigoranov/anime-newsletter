# 1. Get our Node.js toolbox
FROM node:20
WORKDIR /app

# 2. Install ingredients
COPY package.json package-lock.json ./
RUN npm install

# 3. We DO NOT copy the rest of the code here, because we will use a Volume instead!

# 4. Expose the default Vite port
EXPOSE 5173

# 5. Run Vite! (The --host flag is required so Docker lets your browser see it)
CMD ["npm", "run", "dev", "--", "--host"]