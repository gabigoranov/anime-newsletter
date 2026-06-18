pipeline {
    agent any

    stages {
        stage('Deploy') {
            steps {
                sh '''
                    cd /var/www/anime-newsletter
                    git fetch origin
                    git reset --hard origin/main
                    docker compose up -d --build frontend backend
                '''
            }
        }
    }
}