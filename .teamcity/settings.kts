import jetbrains.buildServer.configs.kotlin.v2019_2.*
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.ScriptBuildStep
import jetbrains.buildServer.configs.kotlin.v2019_2.buildSteps.script
import jetbrains.buildServer.configs.kotlin.v2019_2.triggers.vcs

/*
The settings script is an entry point for defining a TeamCity
project hierarchy. The script should contain a single call to the
project() function with a Project instance or an init function as
an argument.

VcsRoots, BuildTypes, Templates, and subprojects can be
registered inside the project using the vcsRoot(), buildType(),
template(), and subProject() methods respectively.

To debug settings scripts in command-line, run the

    mvnDebug org.jetbrains.teamcity:teamcity-configs-maven-plugin:generate

command and attach your debugger to the port 8000.

To debug in IntelliJ Idea, open the 'Maven Projects' tool window (View
-> Tool Windows -> Maven Projects), find the generate task node
(Plugins -> teamcity-configs -> teamcity-configs:generate), the
'Debug' option is available in the context menu for the task.
*/

version = "2020.1"

project {

    params {
        param("teamcity.ui.settings.readOnly", "true")
    }

    buildType(BuildNetSolution)
}

object BuildNetSolution : BuildType({
    name = "Build & Publish Docker Image"
    
    params {
       password("dockerHubPassword", "credentialsJSON:653d0dd1-57f3-44a1-b816-831a756f7724", display = ParameterDisplay.HIDDEN)
    }

    vcs {
        root(DslContext.settingsRoot)
    }

    steps {
        /*script {
            name = "Compile Solution"
            scriptContent = "dotnet build src/Grocery.Tracker.Api.sln"
            dockerImagePlatform = ScriptBuildStep.ImagePlatform.Linux
            dockerImage = "mcr.microsoft.com/dotnet/sdk:5.0-focal"
        }*/
        script {
            name = "Log in to Docker Hub Registry"
            scriptContent = "docker login --username siri8691 --password %dockerHubPassword%"
        }
        script {
            name = "Build Docker Image"
            scriptContent = "docker build -t siri8691/grocery-tracker-console:%build.counter% -t siri8691/grocery-tracker-console:latest ."
        }
        script {
            name = "Push Docker image to Docker hub"
            scriptContent = """
                docker push siri8691/grocery-tracker-console:%build.counter%
                docker push siri8691/grocery-tracker-console:latest
            """.trimIndent()
        }
    }

    triggers {
        vcs {
            branchFilter = "+:main"
        }
    }
})
