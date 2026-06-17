pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Deploy') {
            steps {
                sh "docker compose -f /var/www/anime-newsletter/docker-compose.yml -p anime-newsletter build --no-cache frontend backend"
                sh "docker compose -f /var/www/anime-newsletter/docker-compose.yml -p anime-newsletter up -d --force-recreate frontend backend"
            }
        }
    }
}