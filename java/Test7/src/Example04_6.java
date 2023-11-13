interface Inter {
    void show();
    void method();
}
class Outer {
    public void function() {
        Inter inter = new Inter() {
            @Override
            public void show() {
                System.out.println("show");
            }
            
            @Override
            public void method() {
                System.out.println("method");
            }
        };
        
        inter.show(); 
        inter.method();
    }
}
public class Example04_6 {
    public static void main(String[] args) {
        Outer outer = new Outer();
        outer.function();
    }
}
