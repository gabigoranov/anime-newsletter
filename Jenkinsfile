pipeline {
    agent any

    environment {
        REPO_OWNER = 'gabigoranov'
        REPO_NAME  = 'anime-newsletter'
        GITHUB_CREDENTIALS = credentials('github-token') 
    }

    stages {
        // 1. GET THE FRESH CODE FIRST
        stage('Checkout Code') {
            steps {
                checkout scm
            }
        }

        // 2. NOW NOTIFY GITHUB WITH THE CORRECT GIT_COMMIT VARIABLE
        stage('Notify GitHub Start') {
            steps {
                script {
                    sh """
                        curl -X POST \
                        -H "Authorization: token ${GITHUB_CREDENTIALS}" \
                        -H "Accept: application/vnd.github.v3+json" \
                        https://api.github.com/repos/${REPO_OWNER}/${REPO_NAME}/statuses/${GIT_COMMIT} \
                        -d '{"state": "pending", "target_url": "${BUILD_URL}", "description": "Jenkins is building your app...", "context": "Continuous Integration"}'
                    """
                }
            }
        }

        // 3. FORCE REBUILD WITH FRESH CODE
        stage('Deploy to Docker') {
            steps {
                script {
                    echo "Stopping old containers and removing data volumes..."
                    sh "docker compose down -v"

                    echo "Forcing a clean image build from scratch without cache..."
                    // This flag is valid here! It forces a total rebuild of all code layers.
                    sh "docker compose build --no-cache backend frontend"

                    echo "Starting up updated services..."
                    sh "docker compose up -d backend frontend"
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
            script {
                sh """
                    curl -X POST \
                    -H "Authorization: token ${GITHUB_CREDENTIALS}" \
                    -H "Accept: application/vnd.github.v3+json" \
                    https://api.github.com/repos/${REPO_OWNER}/${REPO_NAME}/statuses/${GIT_COMMIT} \
                    -d '{"state": "success", "target_url": "${BUILD_URL}", "description": "Build and deploy succeeded!", "context": "Continuous Integration"}'
                """
            }
        }
        failure {
            script {
                sh """
                    curl -X POST \
                    -H "Authorization: token ${GITHUB_CREDENTIALS}" \
                    -H "Accept: application/vnd.github.v3+json" \
                    https://api.github.com/repos/${REPO_OWNER}/${REPO_NAME}/statuses/${GIT_COMMIT} \
                    -d '{"state": "failure", "target_url": "${BUILD_URL}", "description": "Build failed. Check Jenkins logs.", "context": "Continuous Integration"}'
                """
            }
        }
    }
}