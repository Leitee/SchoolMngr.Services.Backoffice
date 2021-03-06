//     This code was generated by a Reinforced.Typings tool. 
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.

enum AttendanceEnum { 
	ATTENDED = 1, 
	MISSED = 2, 
	REASON = 3
}
enum ExamTypeEnum { 
	FIRST = 1, 
	SECOND = 2, 
	THIRD = 3, 
	RETRY = 4, 
	FINAL = 5
}
enum RolesEnum { 
	ADMINISTRADOR = 1, 
	TEACHER = 2, 
	STUDENT = 3, 
	DEBUG = -1
}
enum ShiftTimeEnum { 
	MORNING = 1, 
	EVENING = 2, 
	AFTERNOON = 3, 
	NIGHT = 4
}
enum StudentStateEnum { 
	ENROLLED = 1, 
	ACTIVE = 2, 
	INACTIVE = 3, 
	ACHIEVED = 4
}
interface Assingment
{
	StartsTime: any;
	EndsTime: any;
	Time: any;
	Day: number;
	Subject: any;
	Teacher: any;
}
interface Class
{
	Id: number;
	Name: string;
	Shift: ShiftTimeEnum;
	ShiftDescription: string;
	Assingment: Assingment;
	ClassRoom: Room;
}
interface Grade
{
	Id: number;
	Name: string;
}
interface Room
{
	Id: number;
	Description: string;
	Capacity: number;
	HasNetworkConexion: boolean;
	HasScreenProjector: boolean;
}
interface Subject
{
	CodeName: string;
	Description: string;
	Required: any;
	Grade: any;
	Assingments: Assingment[];
}
interface Teacher
{
	Id: number;
	Deleted: boolean;
	Address: string;
	IsTemporary: boolean;
	Obs: string;
	Assingments: Assingment[];
}
