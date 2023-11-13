class Phone {
    public void call() {
        System.out.println("打电话功能");
    }
}

class NewPhone extends Phone {
    public void call() {
        super.call(); // 调用父类的call()方法
        System.out.println("开启语音功能");
        System.out.println("关闭语音功能");
    }
}

public class Example04_2 {
    public static void main(String[] args) {
        Phone phone = new Phone();
        phone.call(); // 调用父类的call()方法

        NewPhone newPhone = new NewPhone();
        newPhone.call(); // 调用重写后的call()方法
    }
}