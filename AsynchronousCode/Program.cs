using AsynchronousCode.Controller;

UserController controller = new UserController();
await controller.updateUser();

Console.WriteLine("---Users---");
await controller.getUsers();