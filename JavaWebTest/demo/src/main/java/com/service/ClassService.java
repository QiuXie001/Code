package com.service;

import com.model.Class;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

public class ClassService {
    // 创建一个List来存储班级信息
    public static List<Class> list = new ArrayList<Class>();
    private static final String URL = "jdbc:mysql://110.40.171.227:3306/studentmanage";
	private static final String USER = "root";
	private static final String PASSWORD = "root";
    
    private static final String SELECT_ALL_CLASSES_SQL = "SELECT classId, className FROM Class";
    
	// 静态初始化块，用于初始化List
    public static void InitClassList() {
        List<Class> list = new ArrayList<>();
        try {
            // 加载驱动
            java.lang.Class.forName("com.mysql.cj.jdbc.Driver");
            // 建立连接
            Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
			
            // 创建PreparedStatement
            PreparedStatement stmt = conn.prepareStatement(SELECT_ALL_CLASSES_SQL);

            // 执行查询
            ResultSet rs = stmt.executeQuery();
            list.clear();
            // 处理结果
            while (rs.next()) {
                Class tmp = new Class();
                tmp.setClassId(rs.getInt("classId"));
                tmp.setClassName(rs.getString("className"));
                list.add(tmp);
            }

            // 关闭资源
            rs.close();
            stmt.close();
            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    // 获取所有班级信息
    public static List<Class> getAllClass() {
		InitClassList();
		// 返回班级信息List
		return list;
	}
	// 根据班级ID获取班级名称
    public static String getClassNameByClassId(int id) {
		// 遍历班级信息List
		for (int i = 0; i < list.size(); i++) {
			// 如果班级ID与传入的ID相等
			if (list.get(i).getClassId() == id) {
				// 返回该班级的名称
				return list.get(i).getClassName();
			}
		}
		// 如果没有找到对应的班级ID，则返回空字符串
		return "";
	}
	// 根据班级ID获取班级信息
    public static Class getOneClassById(int id) {
		// 遍历班级信息List
		for (int i = 0; i < list.size(); i++) {
			// 如果班级ID与传入的ID相等
			if (list.get(i).getClassId() == id) {
				// 返回该班级的信息
				return list.get(i);
			}
		}
		// 如果没有找到对应的班级ID，则返回null
		return null;
	}
	

}