interface Animal2 {
    void sleep();
}
class Cat2 implements Animal2 {
    @Override
    public void sleep() {
        System.out.println("猫 睡觉");
    }
}
class Pig2 implements Animal2 {
    @Override
    public void sleep() {
        System.out.println("猪 睡觉");
    }
}
public class Example04_5 {
    public static void main(String[] args) {
        Cat2 cat2 = new Cat2();
        Animal2 animal2 = (Animal2) cat2; 
        
        Pig2 pig2 = (Pig2) animal2; 
        pig2.sleep();
    }
}
