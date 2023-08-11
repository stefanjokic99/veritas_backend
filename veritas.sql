/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2017                    */
/* Created on:     8/10/2023 10:03:44 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"Case"') and o.name = 'FK_CASE_DEPARTMEN_DEPARTME')
alter table "Case"
   drop constraint FK_CASE_DEPARTMEN_DEPARTME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"Case"') and o.name = 'FK_CASE_RELATIONS_CASESTAT')
alter table "Case"
   drop constraint FK_CASE_RELATIONS_CASESTAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"Case"') and o.name = 'FK_CASE_TYPE_SUBJECTT')
alter table "Case"
   drop constraint FK_CASE_TYPE_SUBJECTT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CasePhase') and o.name = 'FK_CASEPHAS_FAZA_SUBJECTT')
alter table CasePhase
   drop constraint FK_CASEPHAS_FAZA_SUBJECTT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CasePhaseHistory') and o.name = 'FK_CASEPHAS_DURATION__CASEPHAS')
alter table CasePhaseHistory
   drop constraint FK_CASEPHAS_DURATION__CASEPHAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CasePhaseHistory') and o.name = 'FK_CASEPHAS_FOR_CASE_CASE')
alter table CasePhaseHistory
   drop constraint FK_CASEPHAS_FOR_CASE_CASE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CaseStatusHistory') and o.name = 'FK_CASESTAT_RELATIONS_CASESTAT')
alter table CaseStatusHistory
   drop constraint FK_CASESTAT_RELATIONS_CASESTAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CaseStatusHistory') and o.name = 'FK_CASESTAT_RELATIONS_CASE')
alter table CaseStatusHistory
   drop constraint FK_CASESTAT_RELATIONS_CASE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CaseWorker') and o.name = 'FK_CASEWORK_RADI_NA_P_EMPLOYEE')
alter table CaseWorker
   drop constraint FK_CASEWORK_RADI_NA_P_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CaseWorker') and o.name = 'FK_CASEWORK_RELATIONS_JOBPERTY')
alter table CaseWorker
   drop constraint FK_CASEWORK_RELATIONS_JOBPERTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CaseWorker') and o.name = 'FK_CASEWORK_ZAPOSLENI_CASE')
alter table CaseWorker
   drop constraint FK_CASEWORK_ZAPOSLENI_CASE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CourtCases') and o.name = 'FK_COURTCAS_RELATIONS_COURT')
alter table CourtCases
   drop constraint FK_COURTCAS_RELATIONS_COURT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CourtCases') and o.name = 'FK_COURTCAS_RELATIONS_CASE')
alter table CourtCases
   drop constraint FK_COURTCAS_RELATIONS_CASE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EmployeeInDepartment') and o.name = 'FK_EMPLOYEE_DEPARTMEN_DEPARTME')
alter table EmployeeInDepartment
   drop constraint FK_EMPLOYEE_DEPARTMEN_DEPARTME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EmployeeInDepartment') and o.name = 'FK_EMPLOYEE_EMPLOYEEO_EMPLOYEE')
alter table EmployeeInDepartment
   drop constraint FK_EMPLOYEE_EMPLOYEEO_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Hearing') and o.name = 'FK_HEARING_RELATIONS_COURT')
alter table Hearing
   drop constraint FK_HEARING_RELATIONS_COURT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Hearing') and o.name = 'FK_HEARING_RELATIONS_CASE')
alter table Hearing
   drop constraint FK_HEARING_RELATIONS_CASE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('JobPerType') and o.name = 'FK_JOBPERTY_RELATIONS_SUBJECTT')
alter table JobPerType
   drop constraint FK_JOBPERTY_RELATIONS_SUBJECTT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('JobPerType') and o.name = 'FK_JOBPERTY_RELATIONS_JOBCATAL')
alter table JobPerType
   drop constraint FK_JOBPERTY_RELATIONS_JOBCATAL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"Case"')
            and   name  = 'DEPARTMENT'
            and   indid > 0
            and   indid < 255)
   drop index "Case".DEPARTMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"Case"')
            and   name  = 'CASESTATUS_FK'
            and   indid > 0
            and   indid < 255)
   drop index "Case".CASESTATUS_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"Case"')
            and   name  = 'TYPE_FK'
            and   indid > 0
            and   indid < 255)
   drop index "Case".TYPE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Case"')
            and   type = 'U')
   drop table "Case"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CasePhase')
            and   name  = 'PHASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index CasePhase.PHASE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CasePhase')
            and   type = 'U')
   drop table CasePhase
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CasePhaseHistory')
            and   name  = 'FOR_CASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index CasePhaseHistory.FOR_CASE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CasePhaseHistory')
            and   name  = 'PHASE_DURATION_FK'
            and   indid > 0
            and   indid < 255)
   drop index CasePhaseHistory.PHASE_DURATION_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CasePhaseHistory')
            and   type = 'U')
   drop table CasePhaseHistory
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CaseStatus')
            and   type = 'U')
   drop table CaseStatus
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CaseStatusHistory')
            and   name  = 'CASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index CaseStatusHistory.CASE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CaseStatusHistory')
            and   name  = 'CASE_STATUS_FK'
            and   indid > 0
            and   indid < 255)
   drop index CaseStatusHistory.CASE_STATUS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CaseStatusHistory')
            and   type = 'U')
   drop table CaseStatusHistory
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CaseWorker')
            and   name  = 'CASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index CaseWorker.CASE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CaseWorker')
            and   name  = 'WORKER_FK'
            and   indid > 0
            and   indid < 255)
   drop index CaseWorker.WORKER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CaseWorker')
            and   name  = 'JOB_TYPE_FK'
            and   indid > 0
            and   indid < 255)
   drop index CaseWorker.JOB_TYPE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CaseWorker')
            and   type = 'U')
   drop table CaseWorker
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Court')
            and   type = 'U')
   drop table Court
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CourtCases')
            and   name  = 'CASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index CourtCases.CASE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CourtCases')
            and   name  = 'COURT_FK'
            and   indid > 0
            and   indid < 255)
   drop index CourtCases.COURT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CourtCases')
            and   type = 'U')
   drop table CourtCases
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Department')
            and   type = 'U')
   drop table Department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Employee')
            and   type = 'U')
   drop table Employee
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EmployeeInDepartment')
            and   name  = 'EMPLOYEE_FK'
            and   indid > 0
            and   indid < 255)
   drop index EmployeeInDepartment.EMPLOYEE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EmployeeInDepartment')
            and   name  = 'DEPARTMENT_FK'
            and   indid > 0
            and   indid < 255)
   drop index EmployeeInDepartment.DEPARTMENT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EmployeeInDepartment')
            and   type = 'U')
   drop table EmployeeInDepartment
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Hearing')
            and   name  = 'CASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index Hearing.CASE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Hearing')
            and   name  = 'COURT_FK'
            and   indid > 0
            and   indid < 255)
   drop index Hearing.COURT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Hearing')
            and   type = 'U')
   drop table Hearing
go

if exists (select 1
            from  sysobjects
           where  id = object_id('JobCatalog')
            and   type = 'U')
   drop table JobCatalog
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('JobPerType')
            and   name  = 'JOB_FK'
            and   indid > 0
            and   indid < 255)
   drop index JobPerType.JOB_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('JobPerType')
            and   name  = 'TYPE_FK'
            and   indid > 0
            and   indid < 255)
   drop index JobPerType.TYPE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('JobPerType')
            and   type = 'U')
   drop table JobPerType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SubjectType')
            and   type = 'U')
   drop table SubjectType
go

/*==============================================================*/
/* Table: "Case"                                                */
/*==============================================================*/
create table "Case" (
   TypeId               varchar(4)           not null,
   DepartmentId         char(3)              not null,
   Id                   numeric(6)           not null,
   CurrentStatus        numeric(2)           not null,
   Name                 varchar(100)         not null,
   StartDate            datetime             not null,
   Description          varchar(256)         null,
   constraint PK_CASE primary key (DepartmentId, TypeId, Id)
)
go

/*==============================================================*/
/* Index: TYPE_FK                                               */
/*==============================================================*/




create nonclustered index TYPE_FK on "Case" (TypeId ASC)
go

/*==============================================================*/
/* Index: CASESTATUS_FK                                         */
/*==============================================================*/




create nonclustered index CASESTATUS_FK on "Case" (CurrentStatus ASC)
go

/*==============================================================*/
/* Index: DEPARTMENT                                            */
/*==============================================================*/




create nonclustered index DEPARTMENT on "Case" (DepartmentId ASC)
go

/*==============================================================*/
/* Table: CasePhase                                             */
/*==============================================================*/
create table CasePhase (
   TypeId               varchar(4)           not null,
   Id                   varchar(5)           not null,
   Name                 varchar(64)          not null,
   constraint PK_CASEPHASE primary key (TypeId, Id)
)
go

/*==============================================================*/
/* Index: PHASE_FK                                              */
/*==============================================================*/




create nonclustered index PHASE_FK on CasePhase (TypeId ASC)
go

/*==============================================================*/
/* Table: CasePhaseHistory                                      */
/*==============================================================*/
create table CasePhaseHistory (
   TypeId               varchar(4)           not null,
   DepartmentId         char(3)              not null,
   PhaseId              varchar(5)           not null,
   CaseNo               numeric(6)           not null,
   No                   int                  identity,
   StartDate            datetime             not null,
   EndDate              datetime             null,
   constraint PK_CASEPHASEHISTORY primary key (DepartmentId, TypeId, CaseNo, PhaseId, No)
)
go

/*==============================================================*/
/* Index: PHASE_DURATION_FK                                     */
/*==============================================================*/




create nonclustered index PHASE_DURATION_FK on CasePhaseHistory (TypeId ASC,
  PhaseId ASC)
go

/*==============================================================*/
/* Index: FOR_CASE_FK                                           */
/*==============================================================*/




create nonclustered index FOR_CASE_FK on CasePhaseHistory (DepartmentId ASC,
  TypeId ASC,
  CaseNo ASC)
go

/*==============================================================*/
/* Table: CaseStatus                                            */
/*==============================================================*/
create table CaseStatus (
   Id                   numeric(2)           not null,
   Name                 varchar(32)          not null,
   Description          varchar(256)         null,
   constraint PK_CASESTATUS primary key (Id)
)
go

/*==============================================================*/
/* Table: CaseStatusHistory                                     */
/*==============================================================*/
create table CaseStatusHistory (
   TypeId               varchar(4)           not null,
   DepartmentId         char(3)              not null,
   StatusId             numeric(2)           not null,
   CaseId               numeric(6)           not null,
   No                   int                  identity,
   StartDate            datetime             not null,
   EndDate              datetime             null,
   Judge                varchar(35)          not null,
   constraint PK_CASESTATUSHISTORY primary key (DepartmentId, TypeId, CaseId, StatusId, No)
)
go

/*==============================================================*/
/* Index: CASE_STATUS_FK                                        */
/*==============================================================*/




create nonclustered index CASE_STATUS_FK on CaseStatusHistory (StatusId ASC)
go

/*==============================================================*/
/* Index: CASE_FK                                               */
/*==============================================================*/




create nonclustered index CASE_FK on CaseStatusHistory (DepartmentId ASC,
  TypeId ASC,
  CaseId ASC)
go

/*==============================================================*/
/* Table: CaseWorker                                            */
/*==============================================================*/
create table CaseWorker (
   TypeId               varchar(4)           not null,
   DepartmentId         char(3)              not null,
   JobId                numeric(4)           not null,
   CaseId               numeric(6)           not null,
   EmployeeId           nvarchar(450)        not null,
   constraint PK_CASEWORKER primary key (DepartmentId, CaseId, EmployeeId, JobId, TypeId)
)
go

/*==============================================================*/
/* Index: JOB_TYPE_FK                                           */
/*==============================================================*/




create nonclustered index JOB_TYPE_FK on CaseWorker (JobId ASC,
  TypeId ASC)
go

/*==============================================================*/
/* Index: WORKER_FK                                             */
/*==============================================================*/




create nonclustered index WORKER_FK on CaseWorker (EmployeeId ASC)
go

/*==============================================================*/
/* Index: CASE_FK                                               */
/*==============================================================*/




create nonclustered index CASE_FK on CaseWorker (DepartmentId ASC,
  TypeId ASC,
  CaseId ASC)
go

/*==============================================================*/
/* Table: Court                                                 */
/*==============================================================*/
create table Court (
   Id                   char(3)              not null,
   Name                 varchar(32)          not null,
   constraint PK_COURT primary key (Id)
)
go

/*==============================================================*/
/* Table: CourtCases                                            */
/*==============================================================*/
create table CourtCases (
   CourtId              char(3)              not null,
   DepartmentId         char(3)              not null,
   TypeId               varchar(4)           not null,
   CaseId               numeric(6)           not null,
   No                   int                  identity,
   StartTime            datetime             not null,
   EndTime              datetime             null,
   constraint PK_COURTCASES primary key (DepartmentId, TypeId, CaseId, CourtId, No)
)
go

/*==============================================================*/
/* Index: COURT_FK                                              */
/*==============================================================*/




create nonclustered index COURT_FK on CourtCases (CourtId ASC)
go

/*==============================================================*/
/* Index: CASE_FK                                               */
/*==============================================================*/




create nonclustered index CASE_FK on CourtCases (DepartmentId ASC,
  TypeId ASC,
  CaseId ASC)
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Department (
   Id                   char(3)              not null,
   Name                 varchar(32)          not null,
   constraint PK_DEPARTMENT primary key (Id)
)
go

/*==============================================================*/
/* Table: Employee                                              */
/*==============================================================*/
create table Employee (
   Id                   nvarchar(450)        not null,
   Surename             varchar(25)          not null,
   ParentName           varchar(25)          null,
   Forename             varchar(25)          not null,
   Sex                  char(1)              not null,
   JMBG                 varchar(13)          not null,
   constraint PK_EMPLOYEE primary key (Id)
)
go

/*==============================================================*/
/* Table: EmployeeInDepartment                                  */
/*==============================================================*/
create table EmployeeInDepartment (
   DepartmentId         char(3)              not null,
   EmployeeId           nvarchar(450)        not null,
   No                   numeric(6)           identity,
   StartTime            datetime             not null,
   EndTime              datetime             null,
   constraint PK_EMPLOYEEINDEPARTMENT primary key (EmployeeId, DepartmentId, No)
)
go

/*==============================================================*/
/* Index: DEPARTMENT_FK                                         */
/*==============================================================*/




create nonclustered index DEPARTMENT_FK on EmployeeInDepartment (DepartmentId ASC)
go

/*==============================================================*/
/* Index: EMPLOYEE_FK                                           */
/*==============================================================*/




create nonclustered index EMPLOYEE_FK on EmployeeInDepartment (EmployeeId ASC)
go

/*==============================================================*/
/* Table: Hearing                                               */
/*==============================================================*/
create table Hearing (
   CourtId              char(3)              not null,
   TypeId               varchar(4)           not null,
   DepartmentId         char(3)              not null,
   CaseId               numeric(6)           not null,
   No                   int                  identity,
   StartTime            datetime             not null,
   EndTime              datetime             null,
   Record               text                 null,
   constraint PK_HEARING primary key (DepartmentId, TypeId, CaseId, CourtId, No)
)
go

/*==============================================================*/
/* Index: COURT_FK                                              */
/*==============================================================*/




create nonclustered index COURT_FK on Hearing (CourtId ASC)
go

/*==============================================================*/
/* Index: CASE_FK                                               */
/*==============================================================*/




create nonclustered index CASE_FK on Hearing (DepartmentId ASC,
  TypeId ASC,
  CaseId ASC)
go

/*==============================================================*/
/* Table: JobCatalog                                            */
/*==============================================================*/
create table JobCatalog (
   Id                   numeric(4)           not null,
   Name                 varchar(120)         not null,
   PlannedNumber        numeric(3)           not null,
   constraint PK_JOBCATALOG primary key (Id)
)
go

/*==============================================================*/
/* Table: JobPerType                                            */
/*==============================================================*/
create table JobPerType (
   TypeId               varchar(4)           not null,
   JobId                numeric(4)           not null,
   constraint PK_JOBPERTYPE primary key (JobId, TypeId)
)
go

/*==============================================================*/
/* Index: TYPE_FK                                               */
/*==============================================================*/




create nonclustered index TYPE_FK on JobPerType (TypeId ASC)
go

/*==============================================================*/
/* Index: JOB_FK                                                */
/*==============================================================*/




create nonclustered index JOB_FK on JobPerType (JobId ASC)
go

/*==============================================================*/
/* Table: SubjectType                                           */
/*==============================================================*/
create table SubjectType (
   Id                   varchar(4)           not null,
   Name                 varchar(64)          not null,
   constraint PK_SUBJECTTYPE primary key (Id)
)
go

alter table "Case"
   add constraint FK_CASE_DEPARTMEN_DEPARTME foreign key (DepartmentId)
      references Department (Id)
go

alter table "Case"
   add constraint FK_CASE_RELATIONS_CASESTAT foreign key (CurrentStatus)
      references CaseStatus (Id)
go

alter table "Case"
   add constraint FK_CASE_TYPE_SUBJECTT foreign key (TypeId)
      references SubjectType (Id)
go

alter table CasePhase
   add constraint FK_CASEPHAS_FAZA_SUBJECTT foreign key (TypeId)
      references SubjectType (Id)
go

alter table CasePhaseHistory
   add constraint FK_CASEPHAS_DURATION__CASEPHAS foreign key (TypeId, PhaseId)
      references CasePhase (TypeId, Id)
go

alter table CasePhaseHistory
   add constraint FK_CASEPHAS_FOR_CASE_CASE foreign key (DepartmentId, TypeId, CaseNo)
      references "Case" (DepartmentId, TypeId, Id)
go

alter table CaseStatusHistory
   add constraint FK_CASESTAT_RELATIONS_CASESTAT foreign key (StatusId)
      references CaseStatus (Id)
go

alter table CaseStatusHistory
   add constraint FK_CASESTAT_RELATIONS_CASE foreign key (DepartmentId, TypeId, CaseId)
      references "Case" (DepartmentId, TypeId, Id)
go

alter table CaseWorker
   add constraint FK_CASEWORK_RADI_NA_P_EMPLOYEE foreign key (EmployeeId)
      references Employee (Id)
go

alter table CaseWorker
   add constraint FK_CASEWORK_RELATIONS_JOBPERTY foreign key (JobId, TypeId)
      references JobPerType (JobId, TypeId)
go

alter table CaseWorker
   add constraint FK_CASEWORK_ZAPOSLENI_CASE foreign key (DepartmentId, TypeId, CaseId)
      references "Case" (DepartmentId, TypeId, Id)
go

alter table CourtCases
   add constraint FK_COURTCAS_RELATIONS_COURT foreign key (CourtId)
      references Court (Id)
go

alter table CourtCases
   add constraint FK_COURTCAS_RELATIONS_CASE foreign key (DepartmentId, TypeId, CaseId)
      references "Case" (DepartmentId, TypeId, Id)
go

alter table EmployeeInDepartment
   add constraint FK_EMPLOYEE_DEPARTMEN_DEPARTME foreign key (DepartmentId)
      references Department (Id)
go

alter table EmployeeInDepartment
   add constraint FK_EMPLOYEE_EMPLOYEEO_EMPLOYEE foreign key (EmployeeId)
      references Employee (Id)
go

alter table Hearing
   add constraint FK_HEARING_RELATIONS_COURT foreign key (CourtId)
      references Court (Id)
go

alter table Hearing
   add constraint FK_HEARING_RELATIONS_CASE foreign key (DepartmentId, TypeId, CaseId)
      references "Case" (DepartmentId, TypeId, Id)
go

alter table JobPerType
   add constraint FK_JOBPERTY_RELATIONS_SUBJECTT foreign key (TypeId)
      references SubjectType (Id)
go

alter table JobPerType
   add constraint FK_JOBPERTY_RELATIONS_JOBCATAL foreign key (JobId)
      references JobCatalog (Id)
go

