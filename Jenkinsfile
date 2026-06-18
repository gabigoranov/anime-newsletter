pipeline {
    agent any

    stages {
        stage('Deploy') {
            steps {
                dir('/var/www/anime-newsletter') {
                    sh '''
                        git fetch origin
                        git reset --hard origin/main
                        docker compose up -d --build backend frontend
                    '''
                }
            }
        }
    }
}