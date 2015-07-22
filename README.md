## Welcome to the VSO Integration Demos

The VSO Integration Demo is an MVC/WebAPI application highlighting several capabilities of Visual Studio Online 
as of July 17, 2015. You can see the actual website in action at http://vsointegration.azurewebsites.net. This web app
is meant to highlight several integration and customization points of VSO:  

* VSO REST API
* Automated Build and Publish to Azure (http://vsointegration.azurewebsites.net)
* Service Hooks / Web Hook

The intent of this project is to show how VSO and be leveraged and customized, while enabling teams to better 
collarborate.

Upon checkin, VSO will trigger a remote WebApi endpoint to notify an individual a checkin has occured via SMS. An addiitonal 
notificaiton is posted to a team Slack channel. Simultaneously, a continuous integration build is kicked off, building 
and deploying the app to Azure using an on-premises or VSO-hosted build agent. Upon completion, a second SMS and Slack channel 
posting occur, notifying a build has completed.

## VSO REST API

The Home Controller of the web app makes a REST call to the VSO REST API, requesting the 5 most recent changesets. These
are displayed on the home page showing the different types of information the VSO REST api exposes, such as changeset number, 
dates & times, authors, and author profile picture URLs.

## Automated Build and Publish to Azure

Within VSO, an automated build has been setup for continuous integration upon every check in. A build agent has been 
deployed to a VM in Azure, but the project can rely upon a VSO-hosted build agent, if needed. The VM-hosted build agent 
is assigned to the On Premises agent pool, and the VSO-hosted agent is assigned ot the Hosted agent pool. Continuous integration 
builds default to the Hosted agent pool; however, this can be dynamically changed if a build is manually triggered.

## Service Hooks / Web Hook

Several service hooks have been configured for the team project, triggering when any changes are committed and when any build events
occur. One set of service hook triggers integrate with Slack to post events to a #vso channel on the Brostein's slack: 
https://brosteins.slack.com/messages/vso/. Another set trigger Web Hook HTPT POSTS to the WebApi endpoint at 
http://vsointegration.azurewebsites.net/api/Notification. When messages are received by the WebApi endpoint, an SMS is automatically 
sent to Mike's cell phone with the message contents. 


