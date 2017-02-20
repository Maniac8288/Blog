namespace DataModel.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataModel.DataContext context)
        {

            context.Roles.AddOrUpdate(p => p.Id,
                new Role { Id = TypeRoles.Admin, Name = "Admin" },
                new Role { Id = TypeRoles.User, Name = "User" }

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
                 dateAddPost = DateTime.Now,
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
                 dateAddPost = DateTime.Now,
                 upload = "Garry.jpg",
                 Author = "Admin"
             }
           );

            
        }
    }
}
