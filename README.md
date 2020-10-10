# toy-robot-simulator

### Robot Functioning:
* The robot is case sensitive.

### Robot Implementation:
* Since the robot functionality is small I decided to keep things simple and have interfaces together with the implementation. If the functionality starts to grow including more clases then I would evaluate whether to separate the interfaces into a separate project.
* SendCommand method acts like an "interpreter" to the core functionality methods. For the sake of simplicity is integrated in the Robot. If the Robot would require in the future to change drastically the commands or include an additional "interpreter" then I would start to consider separating the interpreting functionality into a separate class/behavior (something resembling the strategy design pattern).

### Console Client Functionality:
* To exit use CTRL + C