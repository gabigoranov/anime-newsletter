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
                dir('/var/www/anime-newsletter') {
                    sh '''
                        git fetch
                        git reset --hard origin/main
                        docker compose up -d --build backend frontend
                    '''
                }
            }
        }
    }
}