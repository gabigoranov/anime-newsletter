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
                // By omitting -f or using the workspace copy, Jenkins reads its fresh checkout
                // While -p anime-newsletter forces it to overwrite your exact running production stack!
                sh "docker compose -p anime-newsletter build --no-cache frontend backend"
                sh "docker compose -p anime-newsletter up -d frontend backend"
            }
        }
    }
}