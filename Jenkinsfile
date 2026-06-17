pipeline {
    agent any

    stages {
        stage('Notify GitHub Start') {
            steps {
                // Sets the commit status to "Pending" on GitHub right at launch
                setGitHubPullRequestStatus(state: 'PENDING', message: 'Jenkins is building your app...', context: 'Continuous Integration')
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
            // Sends a clean green checkmark back to GitHub
            setGitHubPullRequestStatus(state: 'SUCCESS', message: 'Build and deploy succeeded!', context: 'Continuous Integration')
        }
        failure {
            // Sends a clean red X back to GitHub
            setGitHubPullRequestStatus(state: 'FAILURE', message: 'Build failed. Check Jenkins logs.', context: 'Continuous Integration')
        }
    }
}