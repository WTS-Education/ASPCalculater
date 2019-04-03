﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WTS_EDUCATE")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 拡張メソッドの定義
    partial void OnCreated();
    partial void InsertM_User(M_User instance);
    partial void UpdateM_User(M_User instance);
    partial void DeleteM_User(M_User instance);
    partial void InsertT_SCHEDULE(T_SCHEDULE instance);
    partial void UpdateT_SCHEDULE(T_SCHEDULE instance);
    partial void DeleteT_SCHEDULE(T_SCHEDULE instance);
    partial void InsertM_TITLE_COLOR(M_TITLE_COLOR instance);
    partial void UpdateM_TITLE_COLOR(M_TITLE_COLOR instance);
    partial void DeleteM_TITLE_COLOR(M_TITLE_COLOR instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<M_User> M_User
		{
			get
			{
				return this.GetTable<M_User>();
			}
		}
		
		public System.Data.Linq.Table<T_SCHEDULE> T_SCHEDULE
		{
			get
			{
				return this.GetTable<T_SCHEDULE>();
			}
		}
		
		public System.Data.Linq.Table<M_TITLE_COLOR> M_TITLE_COLOR
		{
			get
			{
				return this.GetTable<M_TITLE_COLOR>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.M_User")]
	public partial class M_User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _USER_ID;
		
		private string _LOGIN_ID;
		
		private string _PASSWORD;
		
		private string _EMPLOYEE_NUM;
		
		private string _USER_NAME;
		
		private string _USER_NAME_KANA;
		
		private string _POSITION;
		
		private System.Nullable<System.DateTime> _BIRTHDAY;
		
		private System.DateTime _INSERT_DATE;
		
		private int _INSERT_USER;
		
		private System.Nullable<System.DateTime> _UPDATE_DATE;
		
		private System.Nullable<int> _UPDATE_USER;
		
		private System.Nullable<System.DateTime> _DELETE_DATE;
		
		private System.Nullable<int> _DELETE_USER;
		
		private char _DELETE_FLG;
		
		private EntitySet<M_TITLE_COLOR> _M_TITLE_COLOR;
		
		private EntitySet<T_SCHEDULE> _T_SCHEDULE;
		
    #region 拡張メソッドの定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUSER_IDChanging(int value);
    partial void OnUSER_IDChanged();
    partial void OnLOGIN_IDChanging(string value);
    partial void OnLOGIN_IDChanged();
    partial void OnPASSWORDChanging(string value);
    partial void OnPASSWORDChanged();
    partial void OnEMPLOYEE_NUMChanging(string value);
    partial void OnEMPLOYEE_NUMChanged();
    partial void OnUSER_NAMEChanging(string value);
    partial void OnUSER_NAMEChanged();
    partial void OnUSER_NAME_KANAChanging(string value);
    partial void OnUSER_NAME_KANAChanged();
    partial void OnPOSITIONChanging(string value);
    partial void OnPOSITIONChanged();
    partial void OnBIRTHDAYChanging(System.Nullable<System.DateTime> value);
    partial void OnBIRTHDAYChanged();
    partial void OnINSERT_DATEChanging(System.DateTime value);
    partial void OnINSERT_DATEChanged();
    partial void OnINSERT_USERChanging(int value);
    partial void OnINSERT_USERChanged();
    partial void OnUPDATE_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnUPDATE_DATEChanged();
    partial void OnUPDATE_USERChanging(System.Nullable<int> value);
    partial void OnUPDATE_USERChanged();
    partial void OnDELETE_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnDELETE_DATEChanged();
    partial void OnDELETE_USERChanging(System.Nullable<int> value);
    partial void OnDELETE_USERChanged();
    partial void OnDELETE_FLGChanging(char value);
    partial void OnDELETE_FLGChanged();
    #endregion
		
		public M_User()
		{
			this._M_TITLE_COLOR = new EntitySet<M_TITLE_COLOR>(new Action<M_TITLE_COLOR>(this.attach_M_TITLE_COLOR), new Action<M_TITLE_COLOR>(this.detach_M_TITLE_COLOR));
			this._T_SCHEDULE = new EntitySet<T_SCHEDULE>(new Action<T_SCHEDULE>(this.attach_T_SCHEDULE), new Action<T_SCHEDULE>(this.detach_T_SCHEDULE));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int USER_ID
		{
			get
			{
				return this._USER_ID;
			}
			set
			{
				if ((this._USER_ID != value))
				{
					this.OnUSER_IDChanging(value);
					this.SendPropertyChanging();
					this._USER_ID = value;
					this.SendPropertyChanged("USER_ID");
					this.OnUSER_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LOGIN_ID", DbType="VarChar(70) NOT NULL", CanBeNull=false)]
		public string LOGIN_ID
		{
			get
			{
				return this._LOGIN_ID;
			}
			set
			{
				if ((this._LOGIN_ID != value))
				{
					this.OnLOGIN_IDChanging(value);
					this.SendPropertyChanging();
					this._LOGIN_ID = value;
					this.SendPropertyChanged("LOGIN_ID");
					this.OnLOGIN_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string PASSWORD
		{
			get
			{
				return this._PASSWORD;
			}
			set
			{
				if ((this._PASSWORD != value))
				{
					this.OnPASSWORDChanging(value);
					this.SendPropertyChanging();
					this._PASSWORD = value;
					this.SendPropertyChanged("PASSWORD");
					this.OnPASSWORDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMPLOYEE_NUM", DbType="Char(4) NOT NULL", CanBeNull=false)]
		public string EMPLOYEE_NUM
		{
			get
			{
				return this._EMPLOYEE_NUM;
			}
			set
			{
				if ((this._EMPLOYEE_NUM != value))
				{
					this.OnEMPLOYEE_NUMChanging(value);
					this.SendPropertyChanging();
					this._EMPLOYEE_NUM = value;
					this.SendPropertyChanged("EMPLOYEE_NUM");
					this.OnEMPLOYEE_NUMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_NAME", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string USER_NAME
		{
			get
			{
				return this._USER_NAME;
			}
			set
			{
				if ((this._USER_NAME != value))
				{
					this.OnUSER_NAMEChanging(value);
					this.SendPropertyChanging();
					this._USER_NAME = value;
					this.SendPropertyChanged("USER_NAME");
					this.OnUSER_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_NAME_KANA", DbType="VarChar(50)")]
		public string USER_NAME_KANA
		{
			get
			{
				return this._USER_NAME_KANA;
			}
			set
			{
				if ((this._USER_NAME_KANA != value))
				{
					this.OnUSER_NAME_KANAChanging(value);
					this.SendPropertyChanging();
					this._USER_NAME_KANA = value;
					this.SendPropertyChanged("USER_NAME_KANA");
					this.OnUSER_NAME_KANAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POSITION", DbType="VarChar(320)")]
		public string POSITION
		{
			get
			{
				return this._POSITION;
			}
			set
			{
				if ((this._POSITION != value))
				{
					this.OnPOSITIONChanging(value);
					this.SendPropertyChanging();
					this._POSITION = value;
					this.SendPropertyChanged("POSITION");
					this.OnPOSITIONChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTHDAY", DbType="Date")]
		public System.Nullable<System.DateTime> BIRTHDAY
		{
			get
			{
				return this._BIRTHDAY;
			}
			set
			{
				if ((this._BIRTHDAY != value))
				{
					this.OnBIRTHDAYChanging(value);
					this.SendPropertyChanging();
					this._BIRTHDAY = value;
					this.SendPropertyChanged("BIRTHDAY");
					this.OnBIRTHDAYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INSERT_DATE", DbType="DateTime NOT NULL")]
		public System.DateTime INSERT_DATE
		{
			get
			{
				return this._INSERT_DATE;
			}
			set
			{
				if ((this._INSERT_DATE != value))
				{
					this.OnINSERT_DATEChanging(value);
					this.SendPropertyChanging();
					this._INSERT_DATE = value;
					this.SendPropertyChanged("INSERT_DATE");
					this.OnINSERT_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INSERT_USER", DbType="Int NOT NULL")]
		public int INSERT_USER
		{
			get
			{
				return this._INSERT_USER;
			}
			set
			{
				if ((this._INSERT_USER != value))
				{
					this.OnINSERT_USERChanging(value);
					this.SendPropertyChanging();
					this._INSERT_USER = value;
					this.SendPropertyChanged("INSERT_USER");
					this.OnINSERT_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPDATE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> UPDATE_DATE
		{
			get
			{
				return this._UPDATE_DATE;
			}
			set
			{
				if ((this._UPDATE_DATE != value))
				{
					this.OnUPDATE_DATEChanging(value);
					this.SendPropertyChanging();
					this._UPDATE_DATE = value;
					this.SendPropertyChanged("UPDATE_DATE");
					this.OnUPDATE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPDATE_USER", DbType="Int")]
		public System.Nullable<int> UPDATE_USER
		{
			get
			{
				return this._UPDATE_USER;
			}
			set
			{
				if ((this._UPDATE_USER != value))
				{
					this.OnUPDATE_USERChanging(value);
					this.SendPropertyChanging();
					this._UPDATE_USER = value;
					this.SendPropertyChanged("UPDATE_USER");
					this.OnUPDATE_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> DELETE_DATE
		{
			get
			{
				return this._DELETE_DATE;
			}
			set
			{
				if ((this._DELETE_DATE != value))
				{
					this.OnDELETE_DATEChanging(value);
					this.SendPropertyChanging();
					this._DELETE_DATE = value;
					this.SendPropertyChanged("DELETE_DATE");
					this.OnDELETE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_USER", DbType="Int")]
		public System.Nullable<int> DELETE_USER
		{
			get
			{
				return this._DELETE_USER;
			}
			set
			{
				if ((this._DELETE_USER != value))
				{
					this.OnDELETE_USERChanging(value);
					this.SendPropertyChanging();
					this._DELETE_USER = value;
					this.SendPropertyChanged("DELETE_USER");
					this.OnDELETE_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_FLG", DbType="Char(1) NOT NULL")]
		public char DELETE_FLG
		{
			get
			{
				return this._DELETE_FLG;
			}
			set
			{
				if ((this._DELETE_FLG != value))
				{
					this.OnDELETE_FLGChanging(value);
					this.SendPropertyChanging();
					this._DELETE_FLG = value;
					this.SendPropertyChanged("DELETE_FLG");
					this.OnDELETE_FLGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="M_User_M_TITLE_COLOR", Storage="_M_TITLE_COLOR", ThisKey="USER_ID", OtherKey="INSERT_USER")]
		public EntitySet<M_TITLE_COLOR> M_TITLE_COLOR
		{
			get
			{
				return this._M_TITLE_COLOR;
			}
			set
			{
				this._M_TITLE_COLOR.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="M_User_T_SCHEDULE", Storage="_T_SCHEDULE", ThisKey="USER_ID", OtherKey="INSERT_USER")]
		public EntitySet<T_SCHEDULE> T_SCHEDULE
		{
			get
			{
				return this._T_SCHEDULE;
			}
			set
			{
				this._T_SCHEDULE.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_M_TITLE_COLOR(M_TITLE_COLOR entity)
		{
			this.SendPropertyChanging();
			entity.M_User = this;
		}
		
		private void detach_M_TITLE_COLOR(M_TITLE_COLOR entity)
		{
			this.SendPropertyChanging();
			entity.M_User = null;
		}
		
		private void attach_T_SCHEDULE(T_SCHEDULE entity)
		{
			this.SendPropertyChanging();
			entity.M_User = this;
		}
		
		private void detach_T_SCHEDULE(T_SCHEDULE entity)
		{
			this.SendPropertyChanging();
			entity.M_User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.T_SCHEDULE")]
	public partial class T_SCHEDULE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SCHEDULE_ID;
		
		private System.DateTime _START_TIMESTAMP;
		
		private System.DateTime _END_TIMESTAMP;
		
		private string _TITLE;
		
		private System.Nullable<int> _TITLE_COLOR;
		
		private string _DESCRIPTION;
		
		private string _NOTE;
		
		private int _EDIT_AUTHORITY;
		
		private char _RELEASE_FLG;
		
		private System.DateTime _INSERT_DATE;
		
		private int _INSERT_USER;
		
		private System.Nullable<System.DateTime> _UPDATE_DATE;
		
		private System.Nullable<int> _UPDATE_USER;
		
		private System.Nullable<System.DateTime> _DELETE_DATE;
		
		private System.Nullable<int> _DELETE_USER;
		
		private char _DELETE_FLG;
		
		private EntityRef<M_TITLE_COLOR> _M_TITLE_COLOR;
		
		private EntityRef<M_User> _M_User;
		
    #region 拡張メソッドの定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSCHEDULE_IDChanging(int value);
    partial void OnSCHEDULE_IDChanged();
    partial void OnSTART_TIMESTAMPChanging(System.DateTime value);
    partial void OnSTART_TIMESTAMPChanged();
    partial void OnEND_TIMESTAMPChanging(System.Nullable<System.DateTime> value);
    partial void OnEND_TIMESTAMPChanged();
    partial void OnTITLEChanging(string value);
    partial void OnTITLEChanged();
    partial void OnTITLE_COLORChanging(System.Nullable<int> value);
    partial void OnTITLE_COLORChanged();
    partial void OnDESCRIPTIONChanging(string value);
    partial void OnDESCRIPTIONChanged();
    partial void OnNOTEChanging(string value);
    partial void OnNOTEChanged();
    partial void OnEDIT_AUTHORITYChanging(int value);
    partial void OnEDIT_AUTHORITYChanged();
    partial void OnRELEASE_FLGChanging(char value);
    partial void OnRELEASE_FLGChanged();
    partial void OnINSERT_DATEChanging(System.DateTime value);
    partial void OnINSERT_DATEChanged();
    partial void OnINSERT_USERChanging(int value);
    partial void OnINSERT_USERChanged();
    partial void OnUPDATE_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnUPDATE_DATEChanged();
    partial void OnUPDATE_USERChanging(System.Nullable<int> value);
    partial void OnUPDATE_USERChanged();
    partial void OnDELETE_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnDELETE_DATEChanged();
    partial void OnDELETE_USERChanging(System.Nullable<int> value);
    partial void OnDELETE_USERChanged();
    partial void OnDELETE_FLGChanging(char value);
    partial void OnDELETE_FLGChanged();
    #endregion
		
		public T_SCHEDULE()
		{
			this._M_TITLE_COLOR = default(EntityRef<M_TITLE_COLOR>);
			this._M_User = default(EntityRef<M_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SCHEDULE_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SCHEDULE_ID
		{
			get
			{
				return this._SCHEDULE_ID;
			}
			set
			{
				if ((this._SCHEDULE_ID != value))
				{
					this.OnSCHEDULE_IDChanging(value);
					this.SendPropertyChanging();
					this._SCHEDULE_ID = value;
					this.SendPropertyChanged("SCHEDULE_ID");
					this.OnSCHEDULE_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_START_TIMESTAMP", DbType="DateTime NOT NULL")]
		public System.DateTime START_TIMESTAMP
		{
			get
			{
				return this._START_TIMESTAMP;
			}
			set
			{
				if ((this._START_TIMESTAMP != value))
				{
					this.OnSTART_TIMESTAMPChanging(value);
					this.SendPropertyChanging();
					this._START_TIMESTAMP = value;
					this.SendPropertyChanged("START_TIMESTAMP");
					this.OnSTART_TIMESTAMPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_END_TIMESTAMP", DbType="DateTime")]
		public System.DateTime END_TIMESTAMP
		{
			get
			{
				return this._END_TIMESTAMP;
			}
			set
			{
				if ((this._END_TIMESTAMP != value))
				{
					this.OnEND_TIMESTAMPChanging(value);
					this.SendPropertyChanging();
					this._END_TIMESTAMP = value;
					this.SendPropertyChanged("END_TIMESTAMP");
					this.OnEND_TIMESTAMPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TITLE", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string TITLE
		{
			get
			{
				return this._TITLE;
			}
			set
			{
				if ((this._TITLE != value))
				{
					this.OnTITLEChanging(value);
					this.SendPropertyChanging();
					this._TITLE = value;
					this.SendPropertyChanged("TITLE");
					this.OnTITLEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TITLE_COLOR", DbType="Int")]
		public System.Nullable<int> TITLE_COLOR
		{
			get
			{
				return this._TITLE_COLOR;
			}
			set
			{
				if ((this._TITLE_COLOR != value))
				{
					if (this._M_TITLE_COLOR.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTITLE_COLORChanging(value);
					this.SendPropertyChanging();
					this._TITLE_COLOR = value;
					this.SendPropertyChanged("TITLE_COLOR");
					this.OnTITLE_COLORChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESCRIPTION", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string DESCRIPTION
		{
			get
			{
				return this._DESCRIPTION;
			}
			set
			{
				if ((this._DESCRIPTION != value))
				{
					this.OnDESCRIPTIONChanging(value);
					this.SendPropertyChanging();
					this._DESCRIPTION = value;
					this.SendPropertyChanged("DESCRIPTION");
					this.OnDESCRIPTIONChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOTE", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string NOTE
		{
			get
			{
				return this._NOTE;
			}
			set
			{
				if ((this._NOTE != value))
				{
					this.OnNOTEChanging(value);
					this.SendPropertyChanging();
					this._NOTE = value;
					this.SendPropertyChanged("NOTE");
					this.OnNOTEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EDIT_AUTHORITY", DbType="Int NOT NULL")]
		public int EDIT_AUTHORITY
		{
			get
			{
				return this._EDIT_AUTHORITY;
			}
			set
			{
				if ((this._EDIT_AUTHORITY != value))
				{
					this.OnEDIT_AUTHORITYChanging(value);
					this.SendPropertyChanging();
					this._EDIT_AUTHORITY = value;
					this.SendPropertyChanged("EDIT_AUTHORITY");
					this.OnEDIT_AUTHORITYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RELEASE_FLG", DbType="Char(1) NOT NULL")]
		public char RELEASE_FLG
		{
			get
			{
				return this._RELEASE_FLG;
			}
			set
			{
				if ((this._RELEASE_FLG != value))
				{
					this.OnRELEASE_FLGChanging(value);
					this.SendPropertyChanging();
					this._RELEASE_FLG = value;
					this.SendPropertyChanged("RELEASE_FLG");
					this.OnRELEASE_FLGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INSERT_DATE", DbType="DateTime NOT NULL")]
		public System.DateTime INSERT_DATE
		{
			get
			{
				return this._INSERT_DATE;
			}
			set
			{
				if ((this._INSERT_DATE != value))
				{
					this.OnINSERT_DATEChanging(value);
					this.SendPropertyChanging();
					this._INSERT_DATE = value;
					this.SendPropertyChanged("INSERT_DATE");
					this.OnINSERT_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INSERT_USER", DbType="Int NOT NULL")]
		public int INSERT_USER
		{
			get
			{
				return this._INSERT_USER;
			}
			set
			{
				if ((this._INSERT_USER != value))
				{
					if (this._M_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnINSERT_USERChanging(value);
					this.SendPropertyChanging();
					this._INSERT_USER = value;
					this.SendPropertyChanged("INSERT_USER");
					this.OnINSERT_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPDATE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> UPDATE_DATE
		{
			get
			{
				return this._UPDATE_DATE;
			}
			set
			{
				if ((this._UPDATE_DATE != value))
				{
					this.OnUPDATE_DATEChanging(value);
					this.SendPropertyChanging();
					this._UPDATE_DATE = value;
					this.SendPropertyChanged("UPDATE_DATE");
					this.OnUPDATE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPDATE_USER", DbType="Int")]
		public System.Nullable<int> UPDATE_USER
		{
			get
			{
				return this._UPDATE_USER;
			}
			set
			{
				if ((this._UPDATE_USER != value))
				{
					this.OnUPDATE_USERChanging(value);
					this.SendPropertyChanging();
					this._UPDATE_USER = value;
					this.SendPropertyChanged("UPDATE_USER");
					this.OnUPDATE_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> DELETE_DATE
		{
			get
			{
				return this._DELETE_DATE;
			}
			set
			{
				if ((this._DELETE_DATE != value))
				{
					this.OnDELETE_DATEChanging(value);
					this.SendPropertyChanging();
					this._DELETE_DATE = value;
					this.SendPropertyChanged("DELETE_DATE");
					this.OnDELETE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_USER", DbType="Int")]
		public System.Nullable<int> DELETE_USER
		{
			get
			{
				return this._DELETE_USER;
			}
			set
			{
				if ((this._DELETE_USER != value))
				{
					this.OnDELETE_USERChanging(value);
					this.SendPropertyChanging();
					this._DELETE_USER = value;
					this.SendPropertyChanged("DELETE_USER");
					this.OnDELETE_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_FLG", DbType="Char(1) NOT NULL")]
		public char DELETE_FLG
		{
			get
			{
				return this._DELETE_FLG;
			}
			set
			{
				if ((this._DELETE_FLG != value))
				{
					this.OnDELETE_FLGChanging(value);
					this.SendPropertyChanging();
					this._DELETE_FLG = value;
					this.SendPropertyChanged("DELETE_FLG");
					this.OnDELETE_FLGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="M_TITLE_COLOR_T_SCHEDULE", Storage="_M_TITLE_COLOR", ThisKey="TITLE_COLOR", OtherKey="TITLE_COLOR_ID", IsForeignKey=true)]
		public M_TITLE_COLOR M_TITLE_COLOR
		{
			get
			{
				return this._M_TITLE_COLOR.Entity;
			}
			set
			{
				M_TITLE_COLOR previousValue = this._M_TITLE_COLOR.Entity;
				if (((previousValue != value) 
							|| (this._M_TITLE_COLOR.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._M_TITLE_COLOR.Entity = null;
						previousValue.T_SCHEDULE.Remove(this);
					}
					this._M_TITLE_COLOR.Entity = value;
					if ((value != null))
					{
						value.T_SCHEDULE.Add(this);
						this._TITLE_COLOR = value.TITLE_COLOR_ID;
					}
					else
					{
						this._TITLE_COLOR = default(Nullable<int>);
					}
					this.SendPropertyChanged("M_TITLE_COLOR");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="M_User_T_SCHEDULE", Storage="_M_User", ThisKey="INSERT_USER", OtherKey="USER_ID", IsForeignKey=true)]
		public M_User M_User
		{
			get
			{
				return this._M_User.Entity;
			}
			set
			{
				M_User previousValue = this._M_User.Entity;
				if (((previousValue != value) 
							|| (this._M_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._M_User.Entity = null;
						previousValue.T_SCHEDULE.Remove(this);
					}
					this._M_User.Entity = value;
					if ((value != null))
					{
						value.T_SCHEDULE.Add(this);
						this._INSERT_USER = value.USER_ID;
					}
					else
					{
						this._INSERT_USER = default(int);
					}
					this.SendPropertyChanged("M_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.M_TITLE_COLOR")]
	public partial class M_TITLE_COLOR : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TITLE_COLOR_ID;
		
		private string _TITLE_COLOR_TAG;
		
		private string _TITLE_COLOR_CODE;
		
		private System.DateTime _INSERT_DATE;
		
		private int _INSERT_USER;
		
		private System.Nullable<System.DateTime> _UPDATE_DATE;
		
		private System.Nullable<int> _UPDATE_USER;
		
		private System.Nullable<System.DateTime> _DELETE_DATE;
		
		private System.Nullable<int> _DELETE_USER;
		
		private char _DELETE_FLG;
		
		private EntitySet<T_SCHEDULE> _T_SCHEDULE;
		
		private EntityRef<M_User> _M_User;
		
    #region 拡張メソッドの定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTITLE_COLOR_IDChanging(int value);
    partial void OnTITLE_COLOR_IDChanged();
    partial void OnTITLE_COLOR_TAGChanging(string value);
    partial void OnTITLE_COLOR_TAGChanged();
    partial void OnTITLE_COLOR_CODEChanging(string value);
    partial void OnTITLE_COLOR_CODEChanged();
    partial void OnINSERT_DATEChanging(System.DateTime value);
    partial void OnINSERT_DATEChanged();
    partial void OnINSERT_USERChanging(int value);
    partial void OnINSERT_USERChanged();
    partial void OnUPDATE_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnUPDATE_DATEChanged();
    partial void OnUPDATE_USERChanging(System.Nullable<int> value);
    partial void OnUPDATE_USERChanged();
    partial void OnDELETE_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnDELETE_DATEChanged();
    partial void OnDELETE_USERChanging(System.Nullable<int> value);
    partial void OnDELETE_USERChanged();
    partial void OnDELETE_FLGChanging(char value);
    partial void OnDELETE_FLGChanged();
    #endregion
		
		public M_TITLE_COLOR()
		{
			this._T_SCHEDULE = new EntitySet<T_SCHEDULE>(new Action<T_SCHEDULE>(this.attach_T_SCHEDULE), new Action<T_SCHEDULE>(this.detach_T_SCHEDULE));
			this._M_User = default(EntityRef<M_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TITLE_COLOR_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TITLE_COLOR_ID
		{
			get
			{
				return this._TITLE_COLOR_ID;
			}
			set
			{
				if ((this._TITLE_COLOR_ID != value))
				{
					this.OnTITLE_COLOR_IDChanging(value);
					this.SendPropertyChanging();
					this._TITLE_COLOR_ID = value;
					this.SendPropertyChanged("TITLE_COLOR_ID");
					this.OnTITLE_COLOR_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TITLE_COLOR_TAG", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string TITLE_COLOR_TAG
		{
			get
			{
				return this._TITLE_COLOR_TAG;
			}
			set
			{
				if ((this._TITLE_COLOR_TAG != value))
				{
					this.OnTITLE_COLOR_TAGChanging(value);
					this.SendPropertyChanging();
					this._TITLE_COLOR_TAG = value;
					this.SendPropertyChanged("TITLE_COLOR_TAG");
					this.OnTITLE_COLOR_TAGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TITLE_COLOR_CODE", DbType="Char(7) NOT NULL", CanBeNull=false)]
		public string TITLE_COLOR_CODE
		{
			get
			{
				return this._TITLE_COLOR_CODE;
			}
			set
			{
				if ((this._TITLE_COLOR_CODE != value))
				{
					this.OnTITLE_COLOR_CODEChanging(value);
					this.SendPropertyChanging();
					this._TITLE_COLOR_CODE = value;
					this.SendPropertyChanged("TITLE_COLOR_CODE");
					this.OnTITLE_COLOR_CODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INSERT_DATE", DbType="DateTime NOT NULL")]
		public System.DateTime INSERT_DATE
		{
			get
			{
				return this._INSERT_DATE;
			}
			set
			{
				if ((this._INSERT_DATE != value))
				{
					this.OnINSERT_DATEChanging(value);
					this.SendPropertyChanging();
					this._INSERT_DATE = value;
					this.SendPropertyChanged("INSERT_DATE");
					this.OnINSERT_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INSERT_USER", DbType="Int NOT NULL")]
		public int INSERT_USER
		{
			get
			{
				return this._INSERT_USER;
			}
			set
			{
				if ((this._INSERT_USER != value))
				{
					if (this._M_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnINSERT_USERChanging(value);
					this.SendPropertyChanging();
					this._INSERT_USER = value;
					this.SendPropertyChanged("INSERT_USER");
					this.OnINSERT_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPDATE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> UPDATE_DATE
		{
			get
			{
				return this._UPDATE_DATE;
			}
			set
			{
				if ((this._UPDATE_DATE != value))
				{
					this.OnUPDATE_DATEChanging(value);
					this.SendPropertyChanging();
					this._UPDATE_DATE = value;
					this.SendPropertyChanged("UPDATE_DATE");
					this.OnUPDATE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPDATE_USER", DbType="Int")]
		public System.Nullable<int> UPDATE_USER
		{
			get
			{
				return this._UPDATE_USER;
			}
			set
			{
				if ((this._UPDATE_USER != value))
				{
					this.OnUPDATE_USERChanging(value);
					this.SendPropertyChanging();
					this._UPDATE_USER = value;
					this.SendPropertyChanged("UPDATE_USER");
					this.OnUPDATE_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> DELETE_DATE
		{
			get
			{
				return this._DELETE_DATE;
			}
			set
			{
				if ((this._DELETE_DATE != value))
				{
					this.OnDELETE_DATEChanging(value);
					this.SendPropertyChanging();
					this._DELETE_DATE = value;
					this.SendPropertyChanged("DELETE_DATE");
					this.OnDELETE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_USER", DbType="Int")]
		public System.Nullable<int> DELETE_USER
		{
			get
			{
				return this._DELETE_USER;
			}
			set
			{
				if ((this._DELETE_USER != value))
				{
					this.OnDELETE_USERChanging(value);
					this.SendPropertyChanging();
					this._DELETE_USER = value;
					this.SendPropertyChanged("DELETE_USER");
					this.OnDELETE_USERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DELETE_FLG", DbType="Char(1) NOT NULL")]
		public char DELETE_FLG
		{
			get
			{
				return this._DELETE_FLG;
			}
			set
			{
				if ((this._DELETE_FLG != value))
				{
					this.OnDELETE_FLGChanging(value);
					this.SendPropertyChanging();
					this._DELETE_FLG = value;
					this.SendPropertyChanged("DELETE_FLG");
					this.OnDELETE_FLGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="M_TITLE_COLOR_T_SCHEDULE", Storage="_T_SCHEDULE", ThisKey="TITLE_COLOR_ID", OtherKey="TITLE_COLOR")]
		public EntitySet<T_SCHEDULE> T_SCHEDULE
		{
			get
			{
				return this._T_SCHEDULE;
			}
			set
			{
				this._T_SCHEDULE.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="M_User_M_TITLE_COLOR", Storage="_M_User", ThisKey="INSERT_USER", OtherKey="USER_ID", IsForeignKey=true)]
		public M_User M_User
		{
			get
			{
				return this._M_User.Entity;
			}
			set
			{
				M_User previousValue = this._M_User.Entity;
				if (((previousValue != value) 
							|| (this._M_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._M_User.Entity = null;
						previousValue.M_TITLE_COLOR.Remove(this);
					}
					this._M_User.Entity = value;
					if ((value != null))
					{
						value.M_TITLE_COLOR.Add(this);
						this._INSERT_USER = value.USER_ID;
					}
					else
					{
						this._INSERT_USER = default(int);
					}
					this.SendPropertyChanged("M_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_T_SCHEDULE(T_SCHEDULE entity)
		{
			this.SendPropertyChanging();
			entity.M_TITLE_COLOR = this;
		}
		
		private void detach_T_SCHEDULE(T_SCHEDULE entity)
		{
			this.SendPropertyChanging();
			entity.M_TITLE_COLOR = null;
		}
	}
}
#pragma warning restore 1591
