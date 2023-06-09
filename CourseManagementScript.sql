USE [master]
GO
/****** Object:  Database [CourseManagement4]    Script Date: 12/7/2020 1:18:46 PM ******/
CREATE DATABASE [CourseManagement4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CourseManagement4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSPARTA\MSSQL\DATA\CourseManagement4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CourseManagement4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSPARTA\MSSQL\DATA\CourseManagement4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CourseManagement4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseManagement4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseManagement4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CourseManagement4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CourseManagement4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CourseManagement4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CourseManagement4] SET ARITHABORT OFF 
GO
ALTER DATABASE [CourseManagement4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CourseManagement4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CourseManagement4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CourseManagement4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CourseManagement4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CourseManagement4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CourseManagement4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CourseManagement4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CourseManagement4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CourseManagement4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CourseManagement4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CourseManagement4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CourseManagement4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CourseManagement4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CourseManagement4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CourseManagement4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CourseManagement4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CourseManagement4] SET RECOVERY FULL 
GO
ALTER DATABASE [CourseManagement4] SET  MULTI_USER 
GO
ALTER DATABASE [CourseManagement4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CourseManagement4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CourseManagement4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CourseManagement4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CourseManagement4] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CourseManagement4', N'ON'
GO
ALTER DATABASE [CourseManagement4] SET QUERY_STORE = OFF
GO
USE [CourseManagement4]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[AssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[AssignmentName] [varchar](70) NOT NULL,
	[A_Description] [varchar](255) NULL,
	[PdfLink] [varchar](255) NULL,
	[A_DueDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certificates]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificates](
	[CertificateID] [int] IDENTITY(1,1) NOT NULL,
	[CertificateGranted] [bit] NOT NULL,
	[C_DateReceived] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CertificateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[InstructorID] [int] NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[CourseStarts] [datetime] NULL,
	[CourseEnds] [datetime] NULL,
	[Free] [bit] NOT NULL,
	[FeesInDollars] [int] NULL,
	[NumberOfStudentsEnrolled] [int] NULL,
	[Level] [varchar](50) NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[C_Description] [varchar](255) NULL,
	[C_Disabled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstructorAccount]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructorAccount](
	[InstructorID] [int] IDENTITY(1,1) NOT NULL,
	[UniversityID] [int] NOT NULL,
	[I_Username] [varchar](20) NOT NULL,
	[I_Password] [varchar](20) NOT NULL,
	[I_FirstName] [varchar](30) NOT NULL,
	[I_LastName] [varchar](30) NOT NULL,
	[I_Gender] [varchar](10) NOT NULL,
	[I_Country] [varchar](20) NOT NULL,
	[I_Email] [varchar](50) NOT NULL,
	[Qualification] [varchar](255) NOT NULL,
	[I_AccountCreationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[InstructorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LectureVideos]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LectureVideos](
	[LectureVideoID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[L_Topic] [varchar](50) NULL,
	[DownloadLink] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[LectureVideoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[TypeOfPayment] [varchar](55) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[P_Description] [varchar](255) NULL,
	[P_DueDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Enrolls_In_Courses]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Enrolls_In_Courses](
	[EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[CourseID] [int] NOT NULL,
	[PaymentID] [int] NULL,
	[StudentID] [int] NOT NULL,
	[CertificateID] [int] NULL,
	[RatingsByStudent] [int] NULL,
	[DateOfEnrollment] [datetime] NULL,
	[ProjectCompleted] [bit] NULL,
	[VerifiedByInstructor] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_has_Assignments]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_has_Assignments](
	[St_Ass_Id] [int] IDENTITY(1,1) NOT NULL,
	[EnrollmentID] [int] NOT NULL,
	[AssignmentID] [int] NOT NULL,
	[AssignmentCompleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[St_Ass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAccount]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAccount](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[S_Username] [varchar](20) NOT NULL,
	[S_Password] [varchar](20) NOT NULL,
	[S_FirstName] [varchar](30) NOT NULL,
	[S_LastName] [varchar](30) NOT NULL,
	[S_Gender] [varchar](10) NOT NULL,
	[S_Country] [varchar](30) NOT NULL,
	[S_Email] [varchar](50) NOT NULL,
	[S_AccountCreationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[University]    Script Date: 12/7/2020 1:18:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[University](
	[UniversityID] [int] IDENTITY(1,1) NOT NULL,
	[UniversityName] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UniversityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([AssignmentID], [CourseID], [AssignmentName], [A_Description], [PdfLink], [A_DueDate]) VALUES (1, 1, N'Psych Report Assignment', N'Do some research about mental health problems in different countries and submit a report ', NULL, CAST(N'2018-08-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Assignments] ([AssignmentID], [CourseID], [AssignmentName], [A_Description], [PdfLink], [A_DueDate]) VALUES (2, 2, N'Assignment1CalcII', N' Practise questions of integration', N'http://math.columbia.edu/~rcheng/assets/S2019-HW1.pdf', CAST(N'2020-08-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Assignments] ([AssignmentID], [CourseID], [AssignmentName], [A_Description], [PdfLink], [A_DueDate]) VALUES (3, 2, N'Assignment2CalcII', N' Practise questions of partial differentiation', N'http://math.columbia.edu/~rcheng/assets/S2019-HW1.pdf', CAST(N'2020-08-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Assignments] ([AssignmentID], [CourseID], [AssignmentName], [A_Description], [PdfLink], [A_DueDate]) VALUES (4, 3, N'Assignment1Em', N'greens theorem', N'http://math.columbia.edu/~rcheng/assets/S2019-HW1.pdf', CAST(N'2020-08-04T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Architecture')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Computer Science')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Design')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (6, N'Economics')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Mathematics')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (7, N'Music')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (9, N'Philosophy')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Psychology')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Certificates] ON 

INSERT [dbo].[Certificates] ([CertificateID], [CertificateGranted], [C_DateReceived]) VALUES (1, 1, CAST(N'2019-08-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Certificates] ([CertificateID], [CertificateGranted], [C_DateReceived]) VALUES (2, 0, NULL)
INSERT [dbo].[Certificates] ([CertificateID], [CertificateGranted], [C_DateReceived]) VALUES (3, 0, NULL)
SET IDENTITY_INSERT [dbo].[Certificates] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseID], [CategoryID], [InstructorID], [CourseName], [CourseStarts], [CourseEnds], [Free], [FeesInDollars], [NumberOfStudentsEnrolled], [Level], [Language], [C_Description], [C_Disabled]) VALUES (1, 4, 1, N'Mental Health', CAST(N'2018-07-08T02:00:00.000' AS DateTime), CAST(N'2018-12-06T11:00:00.000' AS DateTime), 1, NULL, 1, N'Beginner', N'English', N'Ending the stigma relating mental health', 1)
INSERT [dbo].[Courses] ([CourseID], [CategoryID], [InstructorID], [CourseName], [CourseStarts], [CourseEnds], [Free], [FeesInDollars], [NumberOfStudentsEnrolled], [Level], [Language], [C_Description], [C_Disabled]) VALUES (2, 3, 2, N'CalculusII', CAST(N'2018-05-04T02:00:06.000' AS DateTime), CAST(N'2021-05-04T11:00:00.000' AS DateTime), 0, 25, 2, N'Hard', N'English', N'Integral Calculus, Differential Calculus and a lot more', 0)
INSERT [dbo].[Courses] ([CourseID], [CategoryID], [InstructorID], [CourseName], [CourseStarts], [CourseEnds], [Free], [FeesInDollars], [NumberOfStudentsEnrolled], [Level], [Language], [C_Description], [C_Disabled]) VALUES (3, 3, 2, N'Engineering Mathematics', CAST(N'2020-08-04T02:00:06.000' AS DateTime), CAST(N'2021-11-04T11:00:00.000' AS DateTime), 0, 30, 0, N'Hard', N'English', N'ODE and power series', 0)
INSERT [dbo].[Courses] ([CourseID], [CategoryID], [InstructorID], [CourseName], [CourseStarts], [CourseEnds], [Free], [FeesInDollars], [NumberOfStudentsEnrolled], [Level], [Language], [C_Description], [C_Disabled]) VALUES (4, 3, 2, N'Calc1', CAST(N'2020-09-04T02:00:06.000' AS DateTime), CAST(N'2021-12-04T11:00:00.000' AS DateTime), 1, NULL, 0, N'Hard', N'English', N'a lot of calc1', 0)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[InstructorAccount] ON 

INSERT [dbo].[InstructorAccount] ([InstructorID], [UniversityID], [I_Username], [I_Password], [I_FirstName], [I_LastName], [I_Gender], [I_Country], [I_Email], [Qualification], [I_AccountCreationDate]) VALUES (1, 1, N'babhum', N'dontopen', N'Babur', N'Humayun', N'Male', N'Pakistan', N'babur@gmail.com', N'PHD in Psychology', CAST(N'2018-07-04T08:01:00.000' AS DateTime))
INSERT [dbo].[InstructorAccount] ([InstructorID], [UniversityID], [I_Username], [I_Password], [I_FirstName], [I_LastName], [I_Gender], [I_Country], [I_Email], [Qualification], [I_AccountCreationDate]) VALUES (2, 2, N'asadsaleem2', N'Habib46#', N'Asad', N'Saleem', N'Male', N'Turkey', N'asadsaleem@gmail.com', N'Masters in Mathematics', CAST(N'2017-08-04T01:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[InstructorAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[LectureVideos] ON 

INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (1, 1, N'What is Mental Health', N'https://youtu.be/MEJVEkVgacg')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (2, 1, N'Effectively cope with stress and adversity', N'https://youtu.be/Bk2-dKH2Ta4')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (3, 1, N'How Your Mind Can Heal Your Body', N'https://youtu.be/AAsxZ-KUGmg')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (4, 2, N'Infinite Series', N'https://youtu.be/Jwtn5_d2YCs')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (5, 2, N'Vector And Surfaces', N'https://youtu.be/ePXRJUyK1UI')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (6, 2, N'Vector Valued Functions', N'https://youtu.be/gjTO0dMZWU4')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (7, 2, N'Partial Differentiation', N'https://youtu.be/m2SogX3AtjI')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (8, 2, N'linear odes', N'https://www.youtube.com/watch?v=Et4Y41ZNyao')
INSERT [dbo].[LectureVideos] ([LectureVideoID], [CourseID], [L_Topic], [DownloadLink]) VALUES (9, 2, N'powerseries', N'https://www.youtube.com/watch?v=DlBQcj_zQk0')
SET IDENTITY_INSERT [dbo].[LectureVideos] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentID], [Amount], [TypeOfPayment]) VALUES (1, 1, N'CreditCard')
INSERT [dbo].[Payment] ([PaymentID], [Amount], [TypeOfPayment]) VALUES (2, 0, N'EasyPaisa')
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectID], [CourseID], [P_Description], [P_DueDate]) VALUES (1, 1, N'Create a prototype of an idea to end stigma about mental health', CAST(N'2019-05-01T11:00:00.000' AS DateTime))
INSERT [dbo].[Project] ([ProjectID], [CourseID], [P_Description], [P_DueDate]) VALUES (2, 2, N'Complementary Coffee Cups', CAST(N'2019-10-06T11:00:00.000' AS DateTime))
INSERT [dbo].[Project] ([ProjectID], [CourseID], [P_Description], [P_DueDate]) VALUES (3, 3, N'1st ORDER ODES', CAST(N'2022-01-06T11:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Student_Enrolls_In_Courses] ON 

INSERT [dbo].[Student_Enrolls_In_Courses] ([EnrollmentID], [ProjectID], [CourseID], [PaymentID], [StudentID], [CertificateID], [RatingsByStudent], [DateOfEnrollment], [ProjectCompleted], [VerifiedByInstructor]) VALUES (1, 1, 2, 1, 1, 1, 4, CAST(N'2019-02-04T00:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[Student_Enrolls_In_Courses] ([EnrollmentID], [ProjectID], [CourseID], [PaymentID], [StudentID], [CertificateID], [RatingsByStudent], [DateOfEnrollment], [ProjectCompleted], [VerifiedByInstructor]) VALUES (2, 1, 2, 2, 2, 2, 3, CAST(N'2019-02-08T00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[Student_Enrolls_In_Courses] ([EnrollmentID], [ProjectID], [CourseID], [PaymentID], [StudentID], [CertificateID], [RatingsByStudent], [DateOfEnrollment], [ProjectCompleted], [VerifiedByInstructor]) VALUES (3, 1, 1, NULL, 1, 3, 3, CAST(N'2019-02-08T00:00:00.000' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[Student_Enrolls_In_Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Student_has_Assignments] ON 

INSERT [dbo].[Student_has_Assignments] ([St_Ass_Id], [EnrollmentID], [AssignmentID], [AssignmentCompleted]) VALUES (1, 1, 2, 1)
INSERT [dbo].[Student_has_Assignments] ([St_Ass_Id], [EnrollmentID], [AssignmentID], [AssignmentCompleted]) VALUES (2, 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Student_has_Assignments] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentAccount] ON 

INSERT [dbo].[StudentAccount] ([StudentID], [S_Username], [S_Password], [S_FirstName], [S_LastName], [S_Gender], [S_Country], [S_Email], [S_AccountCreationDate]) VALUES (1, N'ahuss', N'HaBacha3', N'Ahmed', N'Hussain', N'Male', N'US', N'ahuss@gmail.com', CAST(N'2019-01-04T02:02:00.000' AS DateTime))
INSERT [dbo].[StudentAccount] ([StudentID], [S_Username], [S_Password], [S_FirstName], [S_LastName], [S_Gender], [S_Country], [S_Email], [S_AccountCreationDate]) VALUES (2, N'iqrairfan', N'hanAsh23%', N'Iqra', N'Irfan', N'Female', N'Iran', N'iqra@yahoo.com', CAST(N'2019-01-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[StudentAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[University] ON 

INSERT [dbo].[University] ([UniversityID], [UniversityName]) VALUES (1, N'IqraUniversity')
INSERT [dbo].[University] ([UniversityID], [UniversityName]) VALUES (2, N'HabibUniversity')
INSERT [dbo].[University] ([UniversityID], [UniversityName]) VALUES (3, N'NED')
SET IDENTITY_INSERT [dbo].[University] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Categori__8517B2E07ECFABDB]    Script Date: 12/7/2020 1:18:47 PM ******/
ALTER TABLE [dbo].[Categories] ADD UNIQUE NONCLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Instruct__8AED2FE995C847BD]    Script Date: 12/7/2020 1:18:47 PM ******/
ALTER TABLE [dbo].[InstructorAccount] ADD UNIQUE NONCLUSTERED 
(
	[I_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Instruct__E87D4094186D57E2]    Script Date: 12/7/2020 1:18:47 PM ******/
ALTER TABLE [dbo].[InstructorAccount] ADD UNIQUE NONCLUSTERED 
(
	[I_Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__StudentA__77FCA57B64D4F642]    Script Date: 12/7/2020 1:18:47 PM ******/
ALTER TABLE [dbo].[StudentAccount] ADD UNIQUE NONCLUSTERED 
(
	[S_Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__StudentA__AFE4D2AC26BC7AEE]    Script Date: 12/7/2020 1:18:47 PM ******/
ALTER TABLE [dbo].[StudentAccount] ADD UNIQUE NONCLUSTERED 
(
	[S_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK__Assignmen__Cours__45F365D3] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK__Assignmen__Cours__45F365D3]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK__Courses__Categor__2E1BDC42] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK__Courses__Categor__2E1BDC42]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK__Courses__Instruc__2F10007B] FOREIGN KEY([InstructorID])
REFERENCES [dbo].[InstructorAccount] ([InstructorID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK__Courses__Instruc__2F10007B]
GO
ALTER TABLE [dbo].[InstructorAccount]  WITH CHECK ADD  CONSTRAINT [FK__Instructo__Unive__2B3F6F97] FOREIGN KEY([UniversityID])
REFERENCES [dbo].[University] ([UniversityID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstructorAccount] CHECK CONSTRAINT [FK__Instructo__Unive__2B3F6F97]
GO
ALTER TABLE [dbo].[LectureVideos]  WITH CHECK ADD  CONSTRAINT [FK__LectureVi__Cours__38996AB5] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LectureVideos] CHECK CONSTRAINT [FK__LectureVi__Cours__38996AB5]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK__Project__CourseI__35BCFE0A] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK__Project__CourseI__35BCFE0A]
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses]  WITH CHECK ADD  CONSTRAINT [FK__Student_E__Certi__4222D4EF] FOREIGN KEY([CertificateID])
REFERENCES [dbo].[Certificates] ([CertificateID])
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses] CHECK CONSTRAINT [FK__Student_E__Certi__4222D4EF]
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses]  WITH CHECK ADD  CONSTRAINT [FK__Student_E__Cours__403A8C7D] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses] CHECK CONSTRAINT [FK__Student_E__Cours__403A8C7D]
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses]  WITH CHECK ADD  CONSTRAINT [FK__Student_E__Payme__4316F928] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([PaymentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses] CHECK CONSTRAINT [FK__Student_E__Payme__4316F928]
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses]  WITH CHECK ADD  CONSTRAINT [FK__Student_E__Proje__412EB0B6] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses] CHECK CONSTRAINT [FK__Student_E__Proje__412EB0B6]
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses]  WITH CHECK ADD  CONSTRAINT [FK__Student_E__Stude__3F466844] FOREIGN KEY([StudentID])
REFERENCES [dbo].[StudentAccount] ([StudentID])
GO
ALTER TABLE [dbo].[Student_Enrolls_In_Courses] CHECK CONSTRAINT [FK__Student_E__Stude__3F466844]
GO
ALTER TABLE [dbo].[Student_has_Assignments]  WITH CHECK ADD  CONSTRAINT [FK__Student_h__Assig__48CFD27E] FOREIGN KEY([AssignmentID])
REFERENCES [dbo].[Assignments] ([AssignmentID])
GO
ALTER TABLE [dbo].[Student_has_Assignments] CHECK CONSTRAINT [FK__Student_h__Assig__48CFD27E]
GO
ALTER TABLE [dbo].[Student_has_Assignments]  WITH CHECK ADD  CONSTRAINT [FK__Student_h__Enrol__49C3F6B7] FOREIGN KEY([EnrollmentID])
REFERENCES [dbo].[Student_Enrolls_In_Courses] ([EnrollmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student_has_Assignments] CHECK CONSTRAINT [FK__Student_h__Enrol__49C3F6B7]
GO
USE [master]
GO
ALTER DATABASE [CourseManagement4] SET  READ_WRITE 
GO
