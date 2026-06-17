pipeline {
    agent any

    stages {
        stage('Notify GitHub Start') {
            steps {
                // Uses the universal commit status setter
                githubNotify context: 'Continuous Integration', description: 'Jenkins is building your app...', status: 'PENDING'
            }
        }

        stage('Checkout Code') {
            steps {
                checkout scm
            }
        }

        stage('Deploy to Docker') {
            steps {
                script {
                    echo "Deploying only application containers..."
                    
                    // TARGET SPECIFIC SERVICES: This prevents Jenkins from trying to recreate itself!
                    sh "docker compose up -d --build backend frontend"
                }
            }
        }

        stage('Housekeeping') {
            steps {
                script {
                    echo "Cleaning up dangling images..."
                    sh "docker image prune -f"
                }
            }
        }
    }

    post {
        success {
            githubNotify context: 'Continuous Integration', description: 'Build and deploy succeeded!', status: 'SUCCESS'
        }
        failure {
            githubNotify context: 'Continuous Integration', description: 'Build failed. Check Jenkins logs.', status: 'FAILURE'
        }
    }
}