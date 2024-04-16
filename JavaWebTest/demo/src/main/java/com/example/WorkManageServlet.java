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

@WebServlet("/WorkManage/*")
public class WorkManageServlet extends HttpServlet{
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doPost(request, response);
    }
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("utf-8");
		response.setContentType("text/html;charset=utf-8");
        String uri = request.getRequestURI();
		if (uri.endsWith("/shows")) 
		{
			List<Student> curList = com.service.StudentService.getAllStudent();
			request.setAttribute("studentList", curList);
			request.getRequestDispatcher("/WEB-INF/staffList.jsp").forward(request, response);
		}
        if (uri.endsWith("/update")) // 表示要修改信息
		{
			String id = request.getParameter("id");
			System.out.println(id);
			if (request.getMethod().equalsIgnoreCase("get")) {

				List<Class> allClass = com.service.ClassService.getAllClass();
				request.setAttribute("blongClass", allClass);

				Student curInfo = com.service.StudentService.selectOneStudent(id);
				request.setAttribute("updateStudent", curInfo);
				request.getRequestDispatcher("/WEB-INF/JSP/WorkManage/updateStaff.jsp").forward(request, response);

			}
			else if (request.getMethod().equalsIgnoreCase("post")) // 表示修改完需要提交保存数据
			{
				Student nowData = new Student();
				nowData.setStuCode(request.getParameter("stuCode"));
				nowData.setStuName(request.getParameter("stuName"));
				nowData.setAge(Integer.parseInt(request.getParameter("age")));
				nowData.setSex(Integer.parseInt(request.getParameter("sex")));
				nowData.setTelephone(request.getParameter("telephone"));
				nowData.setAddress(request.getParameter("address"));

				int curClassId = Integer.parseInt(request.getParameter("curClassId"));
				nowData.setBelongClass(curClassId);
				System.out.println("classId" + curClassId);

				String curClassName = com.service.ClassService.getClassNameByClassId(curClassId);
				nowData.setBelongClassName(curClassName);

				com.service.StudentService.updateStudentInfo(nowData);
				response.sendRedirect("/demo/WorkManage/shows");

			}
        }
		if (uri.endsWith("/add")) // 表示新增信息
		{
			if (request.getMethod().equalsIgnoreCase("get")) 
			{
				List<Class> allClass = com.service.ClassService.getAllClass();
				request.setAttribute("blongClass", allClass);
				request.setCharacterEncoding("utf-8");
				response.setContentType("text/html;charset=utf-8");
				request.getRequestDispatcher("/WEB-INF/JSP/WorkManage/addStaff.jsp").forward(request, response);
			} 
			else if (request.getMethod().equalsIgnoreCase("post")) // 说明新增完毕提交信息（弹出新增页面后，提交时，用表单的方式提交）
			{
				Student nowData = new Student();
				nowData.setStuCode(request.getParameter("stuCode"));
				nowData.setStuName(request.getParameter("stuName"));
				nowData.setAge(Integer.parseInt(request.getParameter("age")));
				nowData.setSex(Integer.parseInt(request.getParameter("sex")));
				nowData.setTelephone(request.getParameter("telephone"));
				nowData.setAddress(request.getParameter("address"));

				int curClassId = Integer.parseInt(request.getParameter("curClassId"));
				nowData.setBelongClass(curClassId);
				String curClassName = com.service.ClassService.getClassNameByClassId(curClassId);
				nowData.setBelongClassName(curClassName);

				com.service.StudentService.insertStudentInfo(nowData);
				response.sendRedirect("/demo/WorkManage/shows");
			}
    	}
		
		if (uri.endsWith("/delete")) // 表示删除信息
		{
			String id = request.getParameter("id");

			com.service.StudentService.deleteStudentInfo(id);
			response.sendRedirect("/demo/WorkManage/shows");

		}
	}
}
