pipeline {
  agent {
    docker {
      label 'docker'
      image 'microsoft/dotnet'
    }
  }

  stages {
    stage('Build') {
      steps {
        timeout(10) {
          waitUntil {
            script {
              sh 'git clean -fdx'
              def r = sh returnStatus: true, script: 'dotnet msbuild -t:restore FINT.Model.Resource.Utdanning.sln'
              return r == 0
            }
          }
        }
        sh 'dotnet test FINT.Model.Resource.Utdanning.Tests'
        sh 'dotnet msbuild -t:build,pack -p:Configuration=Release FINT.Model.Resource.Utdanning.sln'
        stash includes: '**/Release/*.nupkg', name: 'libs'
      }
    }

    stage('Deploy') {
      environment {
        BINTRAY = credentials('fint-bintray')
      }
      when {
        branch 'master'
      }
      steps {
        unstash 'libs'
        archiveArtifacts '**/*.nupkg'
        sh "dotnet nuget push FINT.Model.Resource.Utdanning/bin/Release/FINT.Model.Resource.Utdanning.*.nupkg -k ${BINTRAY} -s https://api.bintray.com/nuget/fint/nuget"
      }
    }
  }
}
