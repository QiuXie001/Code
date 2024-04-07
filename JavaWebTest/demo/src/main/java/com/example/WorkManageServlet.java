package com.example;

import com.model.*;
import com.model.Class;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet("/WorkManage")
public class WorkManageServlet extends HttpServlet{
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doPost(request, response);
        request.getRequestDispatcher("/WEB-INF/JSP/WorkManage/staffList.html").forward(request, response);
    }
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // 处理表单提交的数据
        request.setCharacterEncoding("utf-8");
		response.setContentType("text/html;charset=utf-8");
        String uri = request.getRequestURI();
		if (uri.endsWith("/shows")) // 表示需要显示全部数据，提取所有数据进行显示
		{
			List<Student> curList = com.service.StudentService.getAllStudent();
			request.setAttribute("studentList", curList);
			// 请求转发给show.jsp，显示全部数据
			request.getRequestDispatcher("/WEB-INF/JSP/WorkManage/staffList.html").forward(request, response);
            
		}
        if (uri.endsWith("/update")) // 表示要修改信息
		{
			// 进行修改时，如果是get方式过来的，首先应该加载需要修改的数据，显示到修改页面，然后进行修改，修改完毕后进行保存
			String id = request.getParameter("id");
			System.out.println(id);
			if (request.getMethod().equalsIgnoreCase("get")) {
				System.out.println("get method..............");

				// 在弹出修改页面前，先把班级列表加载上，放到请求域中，页面中进行获取
				List<Class> allClass = com.service.ClassService.getAllClass();
				request.setAttribute("blongClass", allClass);

				Student curInfo = com.service.StudentService.selectOneStudent(id);
				request.setAttribute("updateStudent", curInfo);
				// 请求转发给update.jsp，进行数据修改
				request.getRequestDispatcher("/WEB-INF/JSP/WorkManage/staffList.html").forward(request, response);

			}
        }
    }
}
