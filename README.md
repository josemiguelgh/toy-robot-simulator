# toy-robot-simulator

### Branching Strategy:
* "master" contains the latest stable functionality.
* I defined a v0.1 branch to contain the initial version of this app.
* I created a ROBO-001 branch from the v0.1 (ROBO-001 would be the a Jira/Trello ticket #). In this branch I included my code changes with multiple commit/push.
* I created a pull request from ROBO-001 to v0.1 AND from v0.1 to master. I am aware that the pull request should be ideally reviewed by a peer but skipping that for the sake of simplicity.

### Robot Functioning:
* The robot is case sensitive.

### Robot Implementation:
* Since the robot functionality is small I decided to keep things simple and have interfaces together with the implementation. If the functionality starts to grow including more clases then I would evaluate whether to separate the interfaces into a separate project.
* SendCommand method acts like an "interpreter" to the core functionality methods. For the sake of simplicity is integrated in the Robot. If the Robot would require in the future to change drastically the commands or include an additional "interpreter" then I would start to consider separating the interpreting functionality into a separate class/behavior (something resembling the strategy design pattern).

### Console Client Functionality:
* To exit use CTRL + C