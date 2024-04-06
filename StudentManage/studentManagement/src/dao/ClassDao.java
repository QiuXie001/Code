package dao;

import java.util.List;

import model.ClassModel;

public interface ClassDao {

	// 获取所有班级信息
	public List<ClassModel> getAllClass();

	// 根据班级Id获取班级名称
	public String getClassNameByClassId(int id);

}
