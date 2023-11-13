class Fu {
    public Fu() {
        System.out.println("Fu类的无参构造方法");
    }
}

class Zi extends Fu {
    public Zi() {
        super(); // 调用父类的无参构造方法
        System.out.println("Zi类的无参构造方法");
    }
}

public class Example04_3 {
    public static void main(String[] args) {
        Zi zi = new Zi();
    }
}