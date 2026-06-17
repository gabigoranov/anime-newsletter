pipeline {
    agent any

    stages {
        stage('Notify GitHub Start') {
            steps {
                // Native Jenkins GitHub status setter
                step([$class: 'GitHubCommitStatusSetter', 
                    contextSource: [$class: 'ManuallyEnteredCommitStatusContextSource', context: 'Continuous Integration'],
                    statusResultSource: [$class: 'ConditionalStatusResultSource', results: [[$class: 'AnyBuildResult', message: 'Jenkins is building your app...', state: 'PENDING']]]
                ])
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
            step([$class: 'GitHubCommitStatusSetter', 
                contextSource: [$class: 'ManuallyEnteredCommitStatusContextSource', context: 'Continuous Integration'],
                statusResultSource: [$class: 'ConditionalStatusResultSource', results: [[$class: 'AnyBuildResult', message: 'Build and deploy succeeded!', state: 'SUCCESS']]]
            ])
        }
        failure {
            step([$class: 'GitHubCommitStatusSetter', 
                contextSource: [$class: 'ManuallyEnteredCommitStatusContextSource', context: 'Continuous Integration'],
                statusResultSource: [$class: 'ConditionalStatusResultSource', results: [[$class: 'AnyBuildResult', message: 'Build failed. Check Jenkins logs.', state: 'FAILURE']]]
            ])
        }
    }
}