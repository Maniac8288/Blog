namespace DataModel.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

       
       protected override void Seed(Blog.DataContext context)
        {

            context.Roles.AddOrUpdate(p => p.Id,
                new Role { Id = TypeRoles.Admin, Name = "Admin" },
                new Role { Id = TypeRoles.User, Name = "User"}
        
                );
            context.Posts.AddOrUpdate(
             p => p.PostID,
             new Post
             {
                 PostID = 1,
                 NamePost = "������",
                 selectedCategory = "�������",
                 contentPost = "����� ���� �������,��� 3 ����� �������� � ����,��� ����������� ���������� � � ����,��� ��� ����� �������� � �������.������ ������ ��� �� ����� �������,������� ���� ���������� � ������� ��������,������ ������ ���������� � ������ �������.������� �������� ����� ���� ���� - ��,��� �� ����,�� ��� ��������������.����� ��� ����� ������ ��������� ���������� ��������,�� �������� ������ ����� ��������,������� �������� �������,��� ��� ��� ��������� ��������.�������� ������� ������ ����� � ������ ����������,������������� � ������� ��� ����.���� �������� ����� �� �����,� ������ �� ������ �������,����� �� ��������� ���������� ���� ���� �������� � ���������� � ������� ����� ��� ������ ����� ������.� �������� ��������� ����� ����������� ���������� �� ����������.  ��� - �� ���������� ��� ���������,����� ������������ � ���������� ����.�������� ���� ��������.��  ����������� �����,��������������� ��� ������.����������� ����������� ��� ������� ���������. ��� �� �� ����� ������� �煻, � �������� ���� �������.�����������,�������� ����������� ��� �� ��������� � ��� ���������� � ���� ��������� ���� ������� �������,������� ������ ���� ��������� ����� ��������,��� �� �������� ������������� ���.�����������,��� �� 2 ����� 4 ������ �������� � ������� ����� - ���� �� ����������� ���������.������ ���������� ��������� �� ������ ����� ��� ���������� ���������.�� ��������� ���� ��������,������ � ������ ���������� � �������� �� ������ �����.�������� �������,����� ������ ����,��������� ����� ����������� �������� ����,������ ������ ��������� ��� ����������.�������� ������������,��� ��� � ����� ������ ��� ���� ������,������������� ������ �������.������ � �������� ��� ���� ������ �������.��� ������ ������� ������ ������� � �� �������� ������,��� �� ������.������ ��� � �� �����.����� ��� ������������� ����� ������ �������,��� ����������� � ����������� � ����������� ������,������������� �� �������.�������� ������� ��� ����� � ����.",
                 Tags = "������,������",
                 dateAddPost = "2017-01-14",
                 upload = "sherlok.jpg",
                 Author = "Admin"
             },
             new Post
             {
                 PostID = 2,
                 NamePost = "�������� - ����� ������",
                 selectedCategory = "����������",
                 contentPost = "�������� (�� patronus � �����������) � ���������� ��������, ���������� ����������� ��������� ��������. ������ ��� ������ �� ����������. ����� ���� �������� ��� ������ ������ ������������ ����, ��� � �������� ��������� ����� (��� ���������� ��������� ��������). ��������� ���������� ��������� ������ ��� ������-���� ���������, ���������������� ��������� ���������� ��� ����������. � ������� ��������� ��������� ��� ���� ������� ������ ��������, �������� ����������, ��� ��� ��� ����� ������� �����. ��� ������ ��������� ����� ��������� ����� ���������� ������������, ����� ����� ������� ����� ������ �� ���������.���� ������ ��������� ����� �������,�������� ����������,  ����� ��� ���� ����������.����� � ������ ��������� �� � ���� ���� �� ������ �� ��� ����.�������� ������, ����� �������� � ���� ��������� ���� ������� ����� ���� ����������.����� ����� ��������� ����� ���������� �� ���������� ����� ���������� ��� ����������.�������� �������,����� ����� ��������� ���������� � ���������� ������� ������,����� ������� ���������� ��� ���� ��������� �������� ��������� � ��������� ��������.��������� ���������� � ���������� ������ �� ����� ���������� �������� �� ��� ���,���� ��� �� ��������� ����� - ������ ��������������� ���.",
                 Tags = "����� ������,��������,�����",
                 dateAddPost = "2017-01-23",
                 upload = "Garry.jpg",
                 Author = "Admin"
             }
           );

            context.Categories.AddOrUpdate(p => p.Id,

                new Category
                {
                    Id = 1,
                    Name = "����",
                    Childrens = new List<Category> { new Category() { Name = "�����" }, new Category() { Name = "����������" }, new Category() { Name = "�����" }, new Category() { Name = "�������" } }
                },
                new Category
                {
                    Id = 2,
                    Name = "�������",
                    Childrens = new List<Category> { new Category() { Name = "�����" }, new Category() { Name = "����������" }, new Category() { Name = "�����" }, new Category() { Name = "�������" } }
                },
                 new Category
                 {
                     Id = 3,
                     Name = "�������",
                     Childrens = new List<Category> { new Category() { Name = "�����" }, new Category() { Name = "��������" } }
                 }
                );
        }
    }
}
