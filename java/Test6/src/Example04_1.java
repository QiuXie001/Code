class Person {
    public void eat() {
        System.out.println("吃饭");
    }

    public void sleep() {
        System.out.println("睡觉");
    }
}

class Student extends Person {
    public void study() {
        System.out.println("学生在学习");
    }
}

class Teacher extends Person {
    public void teach() {
        System.out.println("老师在教书");
    }
}

public class Example04_1 {
    public static void main(String[] args) {
        Student student = new Student();
        student.eat(); // 继承了Person类的eat()方法
        student.sleep(); // 继承了Person类的sleep()方法
        student.study(); // 特有的study()方法

        Teacher teacher = new Teacher();
        teacher.eat(); // 继承了Person类的eat()方法
        teacher.sleep(); // 继承了Person类的sleep()方法
        teacher.teach(); // 特有的teach()方法
    }
}