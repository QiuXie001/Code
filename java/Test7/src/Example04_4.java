interface Animal {
		    void sleep();
		}
class Cat implements Animal {
    @Override
    public void sleep() {
        System.out.println("猫 睡觉");
    }
    
    public void catchMouse() {
        System.out.println("猫 抓老鼠");
    }
}
public class Example04_4 {
    public static void main(String[] args) {
        Animal animal = new Cat(); 
        animal.sleep(); 
//        Cat cat = new Cat();
//        cat.catchMouse();
    }
}
