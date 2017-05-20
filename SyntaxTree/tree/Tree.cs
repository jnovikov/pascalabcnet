
using System;
using System.Collections;
using System.Collections.Generic;

namespace PascalABCCompiler.SyntaxTree
{
	///<summary>
	///Базовый класс для всех классов синтаксического дерева
	///</summary>
	[Serializable]
	public partial class syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public syntax_tree_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public syntax_tree_node(SourceContext _source_context)
		{
			this._source_context=_source_context;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public syntax_tree_node(SourceContext _source_context,SourceContext sc)
		{
			this._source_context=_source_context;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected SourceContext _source_context;

		///<summary>
		///Позиция в тексте (строка-столбец начала - строка-столбец конца)
		///</summary>
		public SourceContext source_context
		{
			get
			{
				return _source_context;
			}
			set
			{
				_source_context=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public virtual syntax_tree_node Clone()
		{
			syntax_tree_node copy = new syntax_tree_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public virtual syntax_tree_node TypedClone()
		{
			return Clone() as syntax_tree_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public virtual void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public virtual void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public virtual Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public virtual Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public virtual syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public virtual void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Выражение
	///</summary>
	[Serializable]
	public partial class expression : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public expression()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			expression copy = new expression();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new expression TypedClone()
		{
			return Clone() as expression;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Оператор
	///</summary>
	[Serializable]
	public partial class statement : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public statement()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			statement copy = new statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new statement TypedClone()
		{
			return Clone() as statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Блок операторов
	///</summary>
	[Serializable]
	public partial class statement_list : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public statement_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public statement_list(List<statement> _subnodes,token_info _left_logical_bracket,token_info _right_logical_bracket,bool _expr_lambda_body)
		{
			this._subnodes=_subnodes;
			this._left_logical_bracket=_left_logical_bracket;
			this._right_logical_bracket=_right_logical_bracket;
			this._expr_lambda_body=_expr_lambda_body;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public statement_list(List<statement> _subnodes,token_info _left_logical_bracket,token_info _right_logical_bracket,bool _expr_lambda_body,SourceContext sc)
		{
			this._subnodes=_subnodes;
			this._left_logical_bracket=_left_logical_bracket;
			this._right_logical_bracket=_right_logical_bracket;
			this._expr_lambda_body=_expr_lambda_body;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public statement_list(statement elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<statement> _subnodes=new List<statement>();
		protected token_info _left_logical_bracket;
		protected token_info _right_logical_bracket;
		protected bool _expr_lambda_body=new bool();

		///<summary>
		///Список операторов
		///</summary>
		public List<statement> subnodes
		{
			get
			{
				return _subnodes;
			}
			set
			{
				_subnodes=value;
			}
		}

		///<summary>
		///Левая операторная скобка
		///</summary>
		public token_info left_logical_bracket
		{
			get
			{
				return _left_logical_bracket;
			}
			set
			{
				_left_logical_bracket=value;
			}
		}

		///<summary>
		///Правая операторная скобка
		///</summary>
		public token_info right_logical_bracket
		{
			get
			{
				return _right_logical_bracket;
			}
			set
			{
				_right_logical_bracket=value;
			}
		}

		///<summary>
		///Поле, показывающее, что это - тело лямбда-выражения из одного выражения (созданное вызовом NewLambdaBody)
		///</summary>
		public bool expr_lambda_body
		{
			get
			{
				return _expr_lambda_body;
			}
			set
			{
				_expr_lambda_body=value;
			}
		}


		public statement_list Add(statement elem, SourceContext sc = null)
		{
			subnodes.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(statement el)
		{
			subnodes.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<statement> els)
		{
			subnodes.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params statement[] els)
		{
			subnodes.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(statement el)
		{
			var ind = subnodes.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(statement el, statement newel)
		{
			subnodes.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(statement el, IEnumerable<statement> newels)
		{
			subnodes.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(statement el, statement newel)
		{
			subnodes.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(statement el, IEnumerable<statement> newels)
		{
			subnodes.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(statement el)
		{
			return subnodes.Remove(el);
		}
		
		public void ReplaceInList(statement el, statement newel)
		{
			subnodes[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(statement el, IEnumerable<statement> newels)
		{
			var ind = FindIndexInList(el);
			subnodes.RemoveAt(ind);
			subnodes.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<statement> match)
		{
			return subnodes.RemoveAll(match);
		}
		
		public statement Last()
		{
			return subnodes[subnodes.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			statement_list copy = new statement_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (subnodes != null)
			{
				foreach (statement elem in subnodes)
				{
					if (elem != null)
					{
						copy.Add((statement)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			if (left_logical_bracket != null)
			{
				copy.left_logical_bracket = (token_info)left_logical_bracket.Clone();
				copy.left_logical_bracket.Parent = copy;
			}
			if (right_logical_bracket != null)
			{
				copy.right_logical_bracket = (token_info)right_logical_bracket.Clone();
				copy.right_logical_bracket.Parent = copy;
			}
			copy.expr_lambda_body = expr_lambda_body;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new statement_list TypedClone()
		{
			return Clone() as statement_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (subnodes != null)
			{
				foreach (var child in subnodes)
					if (child != null)
						child.Parent = this;
			}
			if (left_logical_bracket != null)
				left_logical_bracket.Parent = this;
			if (right_logical_bracket != null)
				right_logical_bracket.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (subnodes != null)
			{
				foreach (var child in subnodes)
					child?.FillParentsInAllChilds();
			}
			left_logical_bracket?.FillParentsInAllChilds();
			right_logical_bracket?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2 + (subnodes == null ? 0 : subnodes.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return left_logical_bracket;
					case 1:
						return right_logical_bracket;
				}
				Int32 index_counter=ind - 2;
				if(subnodes != null)
				{
					if(index_counter < subnodes.Count)
					{
						return subnodes[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						left_logical_bracket = (token_info)value;
						break;
					case 1:
						right_logical_bracket = (token_info)value;
						break;
				}
				Int32 index_counter=ind - 2;
				if(subnodes != null)
				{
					if(index_counter < subnodes.Count)
					{
						subnodes[index_counter]= (statement)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Идентификатор
	///</summary>
	[Serializable]
	public partial class ident : addressed_value_funcname
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public ident()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ident(string _name)
		{
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ident(string _name,SourceContext sc)
		{
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected string _name;

		///<summary>
		///Строка, представляющая идентификатор
		///</summary>
		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			ident copy = new ident();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new ident TypedClone()
		{
			return Clone() as ident;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Оператор присваивания
	///</summary>
	[Serializable]
	public partial class assign : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public assign()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public assign(addressed_value _to,expression _from,Operators _operator_type)
		{
			this._to=_to;
			this._from=_from;
			this._operator_type=_operator_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public assign(addressed_value _to,expression _from,Operators _operator_type,SourceContext sc)
		{
			this._to=_to;
			this._from=_from;
			this._operator_type=_operator_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _to;
		protected expression _from;
		protected Operators _operator_type;

		///<summary>
		///Левый операнд оператора присваивания (чему присваивать).
		///</summary>
		public addressed_value to
		{
			get
			{
				return _to;
			}
			set
			{
				_to=value;
			}
		}

		///<summary>
		///Выражение в правой части
		///</summary>
		public expression from
		{
			get
			{
				return _from;
			}
			set
			{
				_from=value;
			}
		}

		///<summary>
		///Тип оператора присваивания
		///</summary>
		public Operators operator_type
		{
			get
			{
				return _operator_type;
			}
			set
			{
				_operator_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			assign copy = new assign();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (to != null)
			{
				copy.to = (addressed_value)to.Clone();
				copy.to.Parent = copy;
			}
			if (from != null)
			{
				copy.from = (expression)from.Clone();
				copy.from.Parent = copy;
			}
			copy.operator_type = operator_type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new assign TypedClone()
		{
			return Clone() as assign;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (to != null)
				to.Parent = this;
			if (from != null)
				from.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			to?.FillParentsInAllChilds();
			from?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return to;
					case 1:
						return from;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						to = (addressed_value)value;
						break;
					case 1:
						from = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Бинарное выражение
	///</summary>
	[Serializable]
	public partial class bin_expr : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public bin_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public bin_expr(expression _left,expression _right,Operators _operation_type)
		{
			this._left=_left;
			this._right=_right;
			this._operation_type=_operation_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public bin_expr(expression _left,expression _right,Operators _operation_type,SourceContext sc)
		{
			this._left=_left;
			this._right=_right;
			this._operation_type=_operation_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _left;
		protected expression _right;
		protected Operators _operation_type;

		///<summary>
		///
		///</summary>
		public expression left
		{
			get
			{
				return _left;
			}
			set
			{
				_left=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression right
		{
			get
			{
				return _right;
			}
			set
			{
				_right=value;
			}
		}

		///<summary>
		///
		///</summary>
		public Operators operation_type
		{
			get
			{
				return _operation_type;
			}
			set
			{
				_operation_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			bin_expr copy = new bin_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (left != null)
			{
				copy.left = (expression)left.Clone();
				copy.left.Parent = copy;
			}
			if (right != null)
			{
				copy.right = (expression)right.Clone();
				copy.right.Parent = copy;
			}
			copy.operation_type = operation_type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new bin_expr TypedClone()
		{
			return Clone() as bin_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (left != null)
				left.Parent = this;
			if (right != null)
				right.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			left?.FillParentsInAllChilds();
			right?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return left;
					case 1:
						return right;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						left = (expression)value;
						break;
					case 1:
						right = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Унарное выражение
	///</summary>
	[Serializable]
	public partial class un_expr : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public un_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public un_expr(expression _subnode,Operators _operation_type)
		{
			this._subnode=_subnode;
			this._operation_type=_operation_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public un_expr(expression _subnode,Operators _operation_type,SourceContext sc)
		{
			this._subnode=_subnode;
			this._operation_type=_operation_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _subnode;
		protected Operators _operation_type;

		///<summary>
		///
		///</summary>
		public expression subnode
		{
			get
			{
				return _subnode;
			}
			set
			{
				_subnode=value;
			}
		}

		///<summary>
		///
		///</summary>
		public Operators operation_type
		{
			get
			{
				return _operation_type;
			}
			set
			{
				_operation_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			un_expr copy = new un_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (subnode != null)
			{
				copy.subnode = (expression)subnode.Clone();
				copy.subnode.Parent = copy;
			}
			copy.operation_type = operation_type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new un_expr TypedClone()
		{
			return Clone() as un_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (subnode != null)
				subnode.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			subnode?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return subnode;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						subnode = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Константа
	///</summary>
	[Serializable]
	public partial class const_node : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public const_node()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			const_node copy = new const_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new const_node TypedClone()
		{
			return Clone() as const_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Логическая константа
	///</summary>
	[Serializable]
	public partial class bool_const : const_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public bool_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public bool_const(bool _val)
		{
			this._val=_val;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public bool_const(bool _val,SourceContext sc)
		{
			this._val=_val;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected bool _val;

		///<summary>
		///Значение логической константы
		///</summary>
		public bool val
		{
			get
			{
				return _val;
			}
			set
			{
				_val=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			bool_const copy = new bool_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.val = val;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new bool_const TypedClone()
		{
			return Clone() as bool_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Целая константа
	///</summary>
	[Serializable]
	public partial class int32_const : const_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public int32_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public int32_const(Int32 _val)
		{
			this._val=_val;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public int32_const(Int32 _val,SourceContext sc)
		{
			this._val=_val;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected Int32 _val;

		///<summary>
		///Значение
		///</summary>
		public Int32 val
		{
			get
			{
				return _val;
			}
			set
			{
				_val=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			int32_const copy = new int32_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.val = val;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new int32_const TypedClone()
		{
			return Clone() as int32_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Вещественная константа
	///</summary>
	[Serializable]
	public partial class double_const : const_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public double_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public double_const(double _val)
		{
			this._val=_val;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public double_const(double _val,SourceContext sc)
		{
			this._val=_val;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected double _val;

		///<summary>
		///Значение вещественной константы
		///</summary>
		public double val
		{
			get
			{
				return _val;
			}
			set
			{
				_val=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			double_const copy = new double_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.val = val;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new double_const TypedClone()
		{
			return Clone() as double_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Тело подпрограммы
	///</summary>
	[Serializable]
	public partial class subprogram_body : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public subprogram_body()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public subprogram_body(statement_list _subprogram_code,declarations _subprogram_defs)
		{
			this._subprogram_code=_subprogram_code;
			this._subprogram_defs=_subprogram_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public subprogram_body(statement_list _subprogram_code,declarations _subprogram_defs,SourceContext sc)
		{
			this._subprogram_code=_subprogram_code;
			this._subprogram_defs=_subprogram_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement_list _subprogram_code;
		protected declarations _subprogram_defs;

		///<summary>
		///Блок операторов подпрограммы
		///</summary>
		public statement_list subprogram_code
		{
			get
			{
				return _subprogram_code;
			}
			set
			{
				_subprogram_code=value;
			}
		}

		///<summary>
		///Описания подпрограммы
		///</summary>
		public declarations subprogram_defs
		{
			get
			{
				return _subprogram_defs;
			}
			set
			{
				_subprogram_defs=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			subprogram_body copy = new subprogram_body();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (subprogram_code != null)
			{
				copy.subprogram_code = (statement_list)subprogram_code.Clone();
				copy.subprogram_code.Parent = copy;
			}
			if (subprogram_defs != null)
			{
				copy.subprogram_defs = (declarations)subprogram_defs.Clone();
				copy.subprogram_defs.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new subprogram_body TypedClone()
		{
			return Clone() as subprogram_body;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (subprogram_code != null)
				subprogram_code.Parent = this;
			if (subprogram_defs != null)
				subprogram_defs.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			subprogram_code?.FillParentsInAllChilds();
			subprogram_defs?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return subprogram_code;
					case 1:
						return subprogram_defs;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						subprogram_code = (statement_list)value;
						break;
					case 1:
						subprogram_defs = (declarations)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Значение, имеющее адрес
	///</summary>
	[Serializable]
	public partial class addressed_value : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public addressed_value()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			addressed_value copy = new addressed_value();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new addressed_value TypedClone()
		{
			return Clone() as addressed_value;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Определение типа
	///</summary>
	[Serializable]
	public partial class type_definition : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public type_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition(type_definition_attr_list _attr_list)
		{
			this._attr_list=_attr_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition(type_definition_attr_list _attr_list,SourceContext sc)
		{
			this._attr_list=_attr_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition_attr_list _attr_list;

		///<summary>
		///
		///</summary>
		public type_definition_attr_list attr_list
		{
			get
			{
				return _attr_list;
			}
			set
			{
				_attr_list=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			type_definition copy = new type_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new type_definition TypedClone()
		{
			return Clone() as type_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class roof_dereference : dereference
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public roof_dereference()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public roof_dereference(addressed_value _dereferencing_value)
		{
			this._dereferencing_value=_dereferencing_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public roof_dereference(addressed_value _dereferencing_value,SourceContext sc)
		{
			this._dereferencing_value=_dereferencing_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			roof_dereference copy = new roof_dereference();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (dereferencing_value != null)
			{
				copy.dereferencing_value = (addressed_value)dereferencing_value.Clone();
				copy.dereferencing_value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new roof_dereference TypedClone()
		{
			return Clone() as roof_dereference;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (dereferencing_value != null)
				dereferencing_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			dereferencing_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return dereferencing_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						dereferencing_value = (addressed_value)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Именованное определение типа
	///</summary>
	[Serializable]
	public partial class named_type_reference : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public named_type_reference()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public named_type_reference(List<ident> _names)
		{
			this._names=_names;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public named_type_reference(List<ident> _names,SourceContext sc)
		{
			this._names=_names;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public named_type_reference(type_definition_attr_list _attr_list,List<ident> _names)
		{
			this._attr_list=_attr_list;
			this._names=_names;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public named_type_reference(type_definition_attr_list _attr_list,List<ident> _names,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._names=_names;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public named_type_reference(ident elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<ident> _names=new List<ident>();

		///<summary>
		///Список имен типа
		///</summary>
		public List<ident> names
		{
			get
			{
				return _names;
			}
			set
			{
				_names=value;
			}
		}


		public named_type_reference Add(ident elem, SourceContext sc = null)
		{
			names.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(ident el)
		{
			names.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<ident> els)
		{
			names.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params ident[] els)
		{
			names.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(ident el)
		{
			var ind = names.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(ident el, ident newel)
		{
			names.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(ident el, IEnumerable<ident> newels)
		{
			names.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(ident el, ident newel)
		{
			names.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(ident el, IEnumerable<ident> newels)
		{
			names.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(ident el)
		{
			return names.Remove(el);
		}
		
		public void ReplaceInList(ident el, ident newel)
		{
			names[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(ident el, IEnumerable<ident> newels)
		{
			var ind = FindIndexInList(el);
			names.RemoveAt(ind);
			names.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<ident> match)
		{
			return names.RemoveAll(match);
		}
		
		public ident Last()
		{
			return names[names.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			named_type_reference copy = new named_type_reference();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (names != null)
			{
				foreach (ident elem in names)
				{
					if (elem != null)
					{
						copy.Add((ident)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new named_type_reference TypedClone()
		{
			return Clone() as named_type_reference;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (names != null)
			{
				foreach (var child in names)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			if (names != null)
			{
				foreach (var child in names)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1 + (names == null ? 0 : names.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				Int32 index_counter=ind - 1;
				if(names != null)
				{
					if(index_counter < names.Count)
					{
						return names[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
				Int32 index_counter=ind - 1;
				if(names != null)
				{
					if(index_counter < names.Count)
					{
						names[index_counter]= (ident)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Секция описания переменных (до beginа). Состоит из var_def_statement. Не путать с var_statement - однострочным описанием переменной внутри begin-end
	///</summary>
	[Serializable]
	public partial class variable_definitions : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public variable_definitions()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variable_definitions(List<var_def_statement> _var_definitions)
		{
			this._var_definitions=_var_definitions;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variable_definitions(List<var_def_statement> _var_definitions,SourceContext sc)
		{
			this._var_definitions=_var_definitions;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public variable_definitions(var_def_statement elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<var_def_statement> _var_definitions=new List<var_def_statement>();

		///<summary>
		///Список описаний переменных
		///</summary>
		public List<var_def_statement> var_definitions
		{
			get
			{
				return _var_definitions;
			}
			set
			{
				_var_definitions=value;
			}
		}


		public variable_definitions Add(var_def_statement elem, SourceContext sc = null)
		{
			var_definitions.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(var_def_statement el)
		{
			var_definitions.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<var_def_statement> els)
		{
			var_definitions.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params var_def_statement[] els)
		{
			var_definitions.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(var_def_statement el)
		{
			var ind = var_definitions.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(var_def_statement el, var_def_statement newel)
		{
			var_definitions.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(var_def_statement el, IEnumerable<var_def_statement> newels)
		{
			var_definitions.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(var_def_statement el, var_def_statement newel)
		{
			var_definitions.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(var_def_statement el, IEnumerable<var_def_statement> newels)
		{
			var_definitions.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(var_def_statement el)
		{
			return var_definitions.Remove(el);
		}
		
		public void ReplaceInList(var_def_statement el, var_def_statement newel)
		{
			var_definitions[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(var_def_statement el, IEnumerable<var_def_statement> newels)
		{
			var ind = FindIndexInList(el);
			var_definitions.RemoveAt(ind);
			var_definitions.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<var_def_statement> match)
		{
			return var_definitions.RemoveAll(match);
		}
		
		public var_def_statement Last()
		{
			return var_definitions[var_definitions.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			variable_definitions copy = new variable_definitions();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (var_definitions != null)
			{
				foreach (var_def_statement elem in var_definitions)
				{
					if (elem != null)
					{
						copy.Add((var_def_statement)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new variable_definitions TypedClone()
		{
			return Clone() as variable_definitions;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (var_definitions != null)
			{
				foreach (var child in var_definitions)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (var_definitions != null)
			{
				foreach (var child in var_definitions)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (var_definitions == null ? 0 : var_definitions.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(var_definitions != null)
				{
					if(index_counter < var_definitions.Count)
					{
						return var_definitions[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(var_definitions != null)
				{
					if(index_counter < var_definitions.Count)
					{
						var_definitions[index_counter]= (var_def_statement)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Список идентификаторов
	///</summary>
	[Serializable]
	public partial class ident_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public ident_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ident_list(List<ident> _idents)
		{
			this._idents=_idents;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ident_list(List<ident> _idents,SourceContext sc)
		{
			this._idents=_idents;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public ident_list(ident elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<ident> _idents=new List<ident>();

		///<summary>
		///Список идентификаторов
		///</summary>
		public List<ident> idents
		{
			get
			{
				return _idents;
			}
			set
			{
				_idents=value;
			}
		}


		public ident_list Add(ident elem, SourceContext sc = null)
		{
			idents.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(ident el)
		{
			idents.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<ident> els)
		{
			idents.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params ident[] els)
		{
			idents.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(ident el)
		{
			var ind = idents.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(ident el, ident newel)
		{
			idents.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(ident el, IEnumerable<ident> newels)
		{
			idents.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(ident el, ident newel)
		{
			idents.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(ident el, IEnumerable<ident> newels)
		{
			idents.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(ident el)
		{
			return idents.Remove(el);
		}
		
		public void ReplaceInList(ident el, ident newel)
		{
			idents[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(ident el, IEnumerable<ident> newels)
		{
			var ind = FindIndexInList(el);
			idents.RemoveAt(ind);
			idents.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<ident> match)
		{
			return idents.RemoveAll(match);
		}
		
		public ident Last()
		{
			return idents[idents.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			ident_list copy = new ident_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (idents != null)
			{
				foreach (ident elem in idents)
				{
					if (elem != null)
					{
						copy.Add((ident)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new ident_list TypedClone()
		{
			return Clone() as ident_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (idents != null)
			{
				foreach (var child in idents)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (idents != null)
			{
				foreach (var child in idents)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (idents == null ? 0 : idents.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(idents != null)
				{
					if(index_counter < idents.Count)
					{
						return idents[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(idents != null)
				{
					if(index_counter < idents.Count)
					{
						idents[index_counter]= (ident)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Описание переменных одной строкой. Не содержит var, т.к. встречается исключительно внутри другой конструкции.Может встречаться как до beginа (внутри variable_definitions), так и как внутриблочное описание (внутри var_statement).

	///</summary>
	[Serializable]
	public partial class var_def_statement : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public var_def_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public var_def_statement(ident_list _vars,type_definition _vars_type,expression _inital_value,definition_attribute _var_attr,bool _is_event)
		{
			this._vars=_vars;
			this._vars_type=_vars_type;
			this._inital_value=_inital_value;
			this._var_attr=_var_attr;
			this._is_event=_is_event;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public var_def_statement(ident_list _vars,type_definition _vars_type,expression _inital_value,definition_attribute _var_attr,bool _is_event,SourceContext sc)
		{
			this._vars=_vars;
			this._vars_type=_vars_type;
			this._inital_value=_inital_value;
			this._var_attr=_var_attr;
			this._is_event=_is_event;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _vars;
		protected type_definition _vars_type;
		protected expression _inital_value;
		protected definition_attribute _var_attr;
		protected bool _is_event;

		///<summary>
		///Список имен переменных
		///</summary>
		public ident_list vars
		{
			get
			{
				return _vars;
			}
			set
			{
				_vars=value;
			}
		}

		///<summary>
		///Тип переменных
		///</summary>
		public type_definition vars_type
		{
			get
			{
				return _vars_type;
			}
			set
			{
				_vars_type=value;
			}
		}

		///<summary>
		///Начальное значение переменных
		///</summary>
		public expression inital_value
		{
			get
			{
				return _inital_value;
			}
			set
			{
				_inital_value=value;
			}
		}

		///<summary>
		///
		///</summary>
		public definition_attribute var_attr
		{
			get
			{
				return _var_attr;
			}
			set
			{
				_var_attr=value;
			}
		}

		///<summary>
		///Являются ли переменные событиями
		///</summary>
		public bool is_event
		{
			get
			{
				return _is_event;
			}
			set
			{
				_is_event=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			var_def_statement copy = new var_def_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (vars != null)
			{
				copy.vars = (ident_list)vars.Clone();
				copy.vars.Parent = copy;
			}
			if (vars_type != null)
			{
				copy.vars_type = (type_definition)vars_type.Clone();
				copy.vars_type.Parent = copy;
			}
			if (inital_value != null)
			{
				copy.inital_value = (expression)inital_value.Clone();
				copy.inital_value.Parent = copy;
			}
			copy.var_attr = var_attr;
			copy.is_event = is_event;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new var_def_statement TypedClone()
		{
			return Clone() as var_def_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (vars != null)
				vars.Parent = this;
			if (vars_type != null)
				vars_type.Parent = this;
			if (inital_value != null)
				inital_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			vars?.FillParentsInAllChilds();
			vars_type?.FillParentsInAllChilds();
			inital_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return vars;
					case 1:
						return vars_type;
					case 2:
						return inital_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						vars = (ident_list)value;
						break;
					case 1:
						vars_type = (type_definition)value;
						break;
					case 2:
						inital_value = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Описание
	///</summary>
	[Serializable]
	public partial class declaration : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public declaration()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declaration(attribute_list _attributes)
		{
			this._attributes=_attributes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declaration(attribute_list _attributes,SourceContext sc)
		{
			this._attributes=_attributes;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected attribute_list _attributes;

		///<summary>
		///Список атрибутов описания
		///</summary>
		public attribute_list attributes
		{
			get
			{
				return _attributes;
			}
			set
			{
				_attributes=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			declaration copy = new declaration();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new declaration TypedClone()
		{
			return Clone() as declaration;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attributes;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attributes = (attribute_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Список описаний
	///</summary>
	[Serializable]
	public partial class declarations : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public declarations()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declarations(List<declaration> _defs)
		{
			this._defs=_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declarations(List<declaration> _defs,SourceContext sc)
		{
			this._defs=_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public declarations(declaration elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<declaration> _defs=new List<declaration>();

		///<summary>
		///Список описаний
		///</summary>
		public List<declaration> defs
		{
			get
			{
				return _defs;
			}
			set
			{
				_defs=value;
			}
		}


		public declarations Add(declaration elem, SourceContext sc = null)
		{
			defs.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(declaration el)
		{
			defs.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<declaration> els)
		{
			defs.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params declaration[] els)
		{
			defs.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(declaration el)
		{
			var ind = defs.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(declaration el, declaration newel)
		{
			defs.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(declaration el, IEnumerable<declaration> newels)
		{
			defs.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(declaration el, declaration newel)
		{
			defs.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(declaration el, IEnumerable<declaration> newels)
		{
			defs.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(declaration el)
		{
			return defs.Remove(el);
		}
		
		public void ReplaceInList(declaration el, declaration newel)
		{
			defs[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(declaration el, IEnumerable<declaration> newels)
		{
			var ind = FindIndexInList(el);
			defs.RemoveAt(ind);
			defs.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<declaration> match)
		{
			return defs.RemoveAll(match);
		}
		
		public declaration Last()
		{
			return defs[defs.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			declarations copy = new declarations();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (defs != null)
			{
				foreach (declaration elem in defs)
				{
					if (elem != null)
					{
						copy.Add((declaration)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new declarations TypedClone()
		{
			return Clone() as declarations;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (defs != null)
			{
				foreach (var child in defs)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (defs != null)
			{
				foreach (var child in defs)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (defs == null ? 0 : defs.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						return defs[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						defs[index_counter]= (declaration)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class program_tree : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public program_tree()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_tree(List<compilation_unit> _compilation_units)
		{
			this._compilation_units=_compilation_units;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_tree(List<compilation_unit> _compilation_units,SourceContext sc)
		{
			this._compilation_units=_compilation_units;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public program_tree(compilation_unit elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<compilation_unit> _compilation_units=new List<compilation_unit>();

		///<summary>
		///Список подключенных модулей
		///</summary>
		public List<compilation_unit> compilation_units
		{
			get
			{
				return _compilation_units;
			}
			set
			{
				_compilation_units=value;
			}
		}


		public program_tree Add(compilation_unit elem, SourceContext sc = null)
		{
			compilation_units.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(compilation_unit el)
		{
			compilation_units.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<compilation_unit> els)
		{
			compilation_units.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params compilation_unit[] els)
		{
			compilation_units.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(compilation_unit el)
		{
			var ind = compilation_units.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(compilation_unit el, compilation_unit newel)
		{
			compilation_units.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(compilation_unit el, IEnumerable<compilation_unit> newels)
		{
			compilation_units.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(compilation_unit el, compilation_unit newel)
		{
			compilation_units.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(compilation_unit el, IEnumerable<compilation_unit> newels)
		{
			compilation_units.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(compilation_unit el)
		{
			return compilation_units.Remove(el);
		}
		
		public void ReplaceInList(compilation_unit el, compilation_unit newel)
		{
			compilation_units[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(compilation_unit el, IEnumerable<compilation_unit> newels)
		{
			var ind = FindIndexInList(el);
			compilation_units.RemoveAt(ind);
			compilation_units.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<compilation_unit> match)
		{
			return compilation_units.RemoveAll(match);
		}
		
		public compilation_unit Last()
		{
			return compilation_units[compilation_units.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			program_tree copy = new program_tree();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (compilation_units != null)
			{
				foreach (compilation_unit elem in compilation_units)
				{
					if (elem != null)
					{
						copy.Add((compilation_unit)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new program_tree TypedClone()
		{
			return Clone() as program_tree;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (compilation_units != null)
			{
				foreach (var child in compilation_units)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (compilation_units != null)
			{
				foreach (var child in compilation_units)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (compilation_units == null ? 0 : compilation_units.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(compilation_units != null)
				{
					if(index_counter < compilation_units.Count)
					{
						return compilation_units[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(compilation_units != null)
				{
					if(index_counter < compilation_units.Count)
					{
						compilation_units[index_counter]= (compilation_unit)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Имя программы
	///</summary>
	[Serializable]
	public partial class program_name : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public program_name()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_name(ident _prog_name)
		{
			this._prog_name=_prog_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_name(ident _prog_name,SourceContext sc)
		{
			this._prog_name=_prog_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _prog_name;

		///<summary>
		///Идентификатор - имя программы
		///</summary>
		public ident prog_name
		{
			get
			{
				return _prog_name;
			}
			set
			{
				_prog_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			program_name copy = new program_name();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (prog_name != null)
			{
				copy.prog_name = (ident)prog_name.Clone();
				copy.prog_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new program_name TypedClone()
		{
			return Clone() as program_name;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (prog_name != null)
				prog_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			prog_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return prog_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						prog_name = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Строковая константа
	///</summary>
	[Serializable]
	public partial class string_const : literal
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public string_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public string_const(string _Value)
		{
			this._Value=_Value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public string_const(string _Value,SourceContext sc)
		{
			this._Value=_Value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected string _Value;

		///<summary>
		///Значенеи строковой константы
		///</summary>
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			string_const copy = new string_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.Value = Value;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new string_const TypedClone()
		{
			return Clone() as string_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Список выражений
	///</summary>
	[Serializable]
	public partial class expression_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public expression_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public expression_list(List<expression> _expressions)
		{
			this._expressions=_expressions;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public expression_list(List<expression> _expressions,SourceContext sc)
		{
			this._expressions=_expressions;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public expression_list(expression elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<expression> _expressions=new List<expression>();

		///<summary>
		///Список выражений
		///</summary>
		public List<expression> expressions
		{
			get
			{
				return _expressions;
			}
			set
			{
				_expressions=value;
			}
		}


		public expression_list Add(expression elem, SourceContext sc = null)
		{
			expressions.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(expression el)
		{
			expressions.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<expression> els)
		{
			expressions.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params expression[] els)
		{
			expressions.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(expression el)
		{
			var ind = expressions.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(expression el, expression newel)
		{
			expressions.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(expression el, IEnumerable<expression> newels)
		{
			expressions.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(expression el, expression newel)
		{
			expressions.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(expression el, IEnumerable<expression> newels)
		{
			expressions.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(expression el)
		{
			return expressions.Remove(el);
		}
		
		public void ReplaceInList(expression el, expression newel)
		{
			expressions[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(expression el, IEnumerable<expression> newels)
		{
			var ind = FindIndexInList(el);
			expressions.RemoveAt(ind);
			expressions.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<expression> match)
		{
			return expressions.RemoveAll(match);
		}
		
		public expression Last()
		{
			return expressions[expressions.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			expression_list copy = new expression_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (expressions != null)
			{
				foreach (expression elem in expressions)
				{
					if (elem != null)
					{
						copy.Add((expression)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new expression_list TypedClone()
		{
			return Clone() as expression_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (expressions != null)
			{
				foreach (var child in expressions)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (expressions != null)
			{
				foreach (var child in expressions)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (expressions == null ? 0 : expressions.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(expressions != null)
				{
					if(index_counter < expressions.Count)
					{
						return expressions[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(expressions != null)
				{
					if(index_counter < expressions.Count)
					{
						expressions[index_counter]= (expression)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class dereference : addressed_value_funcname
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public dereference()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public dereference(addressed_value _dereferencing_value)
		{
			this._dereferencing_value=_dereferencing_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public dereference(addressed_value _dereferencing_value,SourceContext sc)
		{
			this._dereferencing_value=_dereferencing_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _dereferencing_value;

		///<summary>
		///
		///</summary>
		public addressed_value dereferencing_value
		{
			get
			{
				return _dereferencing_value;
			}
			set
			{
				_dereferencing_value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			dereference copy = new dereference();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (dereferencing_value != null)
			{
				copy.dereferencing_value = (addressed_value)dereferencing_value.Clone();
				copy.dereferencing_value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new dereference TypedClone()
		{
			return Clone() as dereference;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (dereferencing_value != null)
				dereferencing_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			dereferencing_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return dereferencing_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						dereferencing_value = (addressed_value)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Индекс или индексы
	///</summary>
	[Serializable]
	public partial class indexer : dereference
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public indexer()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexer(expression_list _indexes)
		{
			this._indexes=_indexes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexer(expression_list _indexes,SourceContext sc)
		{
			this._indexes=_indexes;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexer(addressed_value _dereferencing_value,expression_list _indexes)
		{
			this._dereferencing_value=_dereferencing_value;
			this._indexes=_indexes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexer(addressed_value _dereferencing_value,expression_list _indexes,SourceContext sc)
		{
			this._dereferencing_value=_dereferencing_value;
			this._indexes=_indexes;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression_list _indexes;

		///<summary>
		///Список индексов
		///</summary>
		public expression_list indexes
		{
			get
			{
				return _indexes;
			}
			set
			{
				_indexes=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			indexer copy = new indexer();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (dereferencing_value != null)
			{
				copy.dereferencing_value = (addressed_value)dereferencing_value.Clone();
				copy.dereferencing_value.Parent = copy;
			}
			if (indexes != null)
			{
				copy.indexes = (expression_list)indexes.Clone();
				copy.indexes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new indexer TypedClone()
		{
			return Clone() as indexer;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (dereferencing_value != null)
				dereferencing_value.Parent = this;
			if (indexes != null)
				indexes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			dereferencing_value?.FillParentsInAllChilds();
			indexes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return dereferencing_value;
					case 1:
						return indexes;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						dereferencing_value = (addressed_value)value;
						break;
					case 1:
						indexes = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Цикл for
	///</summary>
	[Serializable]
	public partial class for_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public for_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public for_node(ident _loop_variable,expression _initial_value,expression _finish_value,statement _statements,for_cycle_type _cycle_type,expression _increment_value,type_definition _type_name,bool _create_loop_variable)
		{
			this._loop_variable=_loop_variable;
			this._initial_value=_initial_value;
			this._finish_value=_finish_value;
			this._statements=_statements;
			this._cycle_type=_cycle_type;
			this._increment_value=_increment_value;
			this._type_name=_type_name;
			this._create_loop_variable=_create_loop_variable;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public for_node(ident _loop_variable,expression _initial_value,expression _finish_value,statement _statements,for_cycle_type _cycle_type,expression _increment_value,type_definition _type_name,bool _create_loop_variable,SourceContext sc)
		{
			this._loop_variable=_loop_variable;
			this._initial_value=_initial_value;
			this._finish_value=_finish_value;
			this._statements=_statements;
			this._cycle_type=_cycle_type;
			this._increment_value=_increment_value;
			this._type_name=_type_name;
			this._create_loop_variable=_create_loop_variable;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _loop_variable;
		protected expression _initial_value;
		protected expression _finish_value;
		protected statement _statements;
		protected for_cycle_type _cycle_type;
		protected expression _increment_value;
		protected type_definition _type_name;
		protected bool _create_loop_variable;

		///<summary>
		///Переменная цикла for
		///</summary>
		public ident loop_variable
		{
			get
			{
				return _loop_variable;
			}
			set
			{
				_loop_variable=value;
			}
		}

		///<summary>
		///Начальное значение переменной цикла
		///</summary>
		public expression initial_value
		{
			get
			{
				return _initial_value;
			}
			set
			{
				_initial_value=value;
			}
		}

		///<summary>
		///Конечное значение переменной цикла
		///</summary>
		public expression finish_value
		{
			get
			{
				return _finish_value;
			}
			set
			{
				_finish_value=value;
			}
		}

		///<summary>
		///Тело цикла
		///</summary>
		public statement statements
		{
			get
			{
				return _statements;
			}
			set
			{
				_statements=value;
			}
		}

		///<summary>
		///
		///</summary>
		public for_cycle_type cycle_type
		{
			get
			{
				return _cycle_type;
			}
			set
			{
				_cycle_type=value;
			}
		}

		///<summary>
		///Шаг переменной цикла
		///</summary>
		public expression increment_value
		{
			get
			{
				return _increment_value;
			}
			set
			{
				_increment_value=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public bool create_loop_variable
		{
			get
			{
				return _create_loop_variable;
			}
			set
			{
				_create_loop_variable=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			for_node copy = new for_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (loop_variable != null)
			{
				copy.loop_variable = (ident)loop_variable.Clone();
				copy.loop_variable.Parent = copy;
			}
			if (initial_value != null)
			{
				copy.initial_value = (expression)initial_value.Clone();
				copy.initial_value.Parent = copy;
			}
			if (finish_value != null)
			{
				copy.finish_value = (expression)finish_value.Clone();
				copy.finish_value.Parent = copy;
			}
			if (statements != null)
			{
				copy.statements = (statement)statements.Clone();
				copy.statements.Parent = copy;
			}
			copy.cycle_type = cycle_type;
			if (increment_value != null)
			{
				copy.increment_value = (expression)increment_value.Clone();
				copy.increment_value.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (type_definition)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			copy.create_loop_variable = create_loop_variable;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new for_node TypedClone()
		{
			return Clone() as for_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (loop_variable != null)
				loop_variable.Parent = this;
			if (initial_value != null)
				initial_value.Parent = this;
			if (finish_value != null)
				finish_value.Parent = this;
			if (statements != null)
				statements.Parent = this;
			if (increment_value != null)
				increment_value.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			loop_variable?.FillParentsInAllChilds();
			initial_value?.FillParentsInAllChilds();
			finish_value?.FillParentsInAllChilds();
			statements?.FillParentsInAllChilds();
			increment_value?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return loop_variable;
					case 1:
						return initial_value;
					case 2:
						return finish_value;
					case 3:
						return statements;
					case 4:
						return increment_value;
					case 5:
						return type_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						loop_variable = (ident)value;
						break;
					case 1:
						initial_value = (expression)value;
						break;
					case 2:
						finish_value = (expression)value;
						break;
					case 3:
						statements = (statement)value;
						break;
					case 4:
						increment_value = (expression)value;
						break;
					case 5:
						type_name = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Цикл с постусловием (repeat)
	///</summary>
	[Serializable]
	public partial class repeat_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public repeat_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public repeat_node(statement _statements,expression _expr)
		{
			this._statements=_statements;
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public repeat_node(statement _statements,expression _expr,SourceContext sc)
		{
			this._statements=_statements;
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement _statements;
		protected expression _expr;

		///<summary>
		///Тело цикла
		///</summary>
		public statement statements
		{
			get
			{
				return _statements;
			}
			set
			{
				_statements=value;
			}
		}

		///<summary>
		///Условие завершения цикла
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			repeat_node copy = new repeat_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (statements != null)
			{
				copy.statements = (statement)statements.Clone();
				copy.statements.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new repeat_node TypedClone()
		{
			return Clone() as repeat_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (statements != null)
				statements.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			statements?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return statements;
					case 1:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						statements = (statement)value;
						break;
					case 1:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Цикл ПОКА
	///</summary>
	[Serializable]
	public partial class while_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public while_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public while_node(expression _expr,statement _statements,WhileCycleType _CycleType)
		{
			this._expr=_expr;
			this._statements=_statements;
			this._CycleType=_CycleType;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public while_node(expression _expr,statement _statements,WhileCycleType _CycleType,SourceContext sc)
		{
			this._expr=_expr;
			this._statements=_statements;
			this._CycleType=_CycleType;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _expr;
		protected statement _statements;
		protected WhileCycleType _CycleType;

		///<summary>
		///Условие цикла
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}

		///<summary>
		///Тело цикла
		///</summary>
		public statement statements
		{
			get
			{
				return _statements;
			}
			set
			{
				_statements=value;
			}
		}

		///<summary>
		///Тип цикла ПОКА
		///</summary>
		public WhileCycleType CycleType
		{
			get
			{
				return _CycleType;
			}
			set
			{
				_CycleType=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			while_node copy = new while_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			if (statements != null)
			{
				copy.statements = (statement)statements.Clone();
				copy.statements.Parent = copy;
			}
			copy.CycleType = CycleType;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new while_node TypedClone()
		{
			return Clone() as while_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr != null)
				expr.Parent = this;
			if (statements != null)
				statements.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
			statements?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr;
					case 1:
						return statements;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr = (expression)value;
						break;
					case 1:
						statements = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Условный оператор
	///</summary>
	[Serializable]
	public partial class if_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public if_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public if_node(expression _condition,statement _then_body,statement _else_body)
		{
			this._condition=_condition;
			this._then_body=_then_body;
			this._else_body=_else_body;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public if_node(expression _condition,statement _then_body,statement _else_body,SourceContext sc)
		{
			this._condition=_condition;
			this._then_body=_then_body;
			this._else_body=_else_body;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _condition;
		protected statement _then_body;
		protected statement _else_body;

		///<summary>
		///Условие
		///</summary>
		public expression condition
		{
			get
			{
				return _condition;
			}
			set
			{
				_condition=value;
			}
		}

		///<summary>
		///Оператор по ветви then
		///</summary>
		public statement then_body
		{
			get
			{
				return _then_body;
			}
			set
			{
				_then_body=value;
			}
		}

		///<summary>
		///Оператор по ветви else
		///</summary>
		public statement else_body
		{
			get
			{
				return _else_body;
			}
			set
			{
				_else_body=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			if_node copy = new if_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (condition != null)
			{
				copy.condition = (expression)condition.Clone();
				copy.condition.Parent = copy;
			}
			if (then_body != null)
			{
				copy.then_body = (statement)then_body.Clone();
				copy.then_body.Parent = copy;
			}
			if (else_body != null)
			{
				copy.else_body = (statement)else_body.Clone();
				copy.else_body.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new if_node TypedClone()
		{
			return Clone() as if_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (condition != null)
				condition.Parent = this;
			if (then_body != null)
				then_body.Parent = this;
			if (else_body != null)
				else_body.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			condition?.FillParentsInAllChilds();
			then_body?.FillParentsInAllChilds();
			else_body?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return condition;
					case 1:
						return then_body;
					case 2:
						return else_body;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						condition = (expression)value;
						break;
					case 1:
						then_body = (statement)value;
						break;
					case 2:
						else_body = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class ref_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public ref_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ref_type(type_definition _pointed_to)
		{
			this._pointed_to=_pointed_to;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ref_type(type_definition _pointed_to,SourceContext sc)
		{
			this._pointed_to=_pointed_to;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ref_type(type_definition_attr_list _attr_list,type_definition _pointed_to)
		{
			this._attr_list=_attr_list;
			this._pointed_to=_pointed_to;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ref_type(type_definition_attr_list _attr_list,type_definition _pointed_to,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._pointed_to=_pointed_to;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _pointed_to;

		///<summary>
		///
		///</summary>
		public type_definition pointed_to
		{
			get
			{
				return _pointed_to;
			}
			set
			{
				_pointed_to=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			ref_type copy = new ref_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (pointed_to != null)
			{
				copy.pointed_to = (type_definition)pointed_to.Clone();
				copy.pointed_to.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new ref_type TypedClone()
		{
			return Clone() as ref_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (pointed_to != null)
				pointed_to.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			pointed_to?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return pointed_to;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						pointed_to = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Диапазон
	///</summary>
	[Serializable]
	public partial class diapason : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public diapason()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diapason(expression _left,expression _right)
		{
			this._left=_left;
			this._right=_right;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diapason(expression _left,expression _right,SourceContext sc)
		{
			this._left=_left;
			this._right=_right;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diapason(type_definition_attr_list _attr_list,expression _left,expression _right)
		{
			this._attr_list=_attr_list;
			this._left=_left;
			this._right=_right;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diapason(type_definition_attr_list _attr_list,expression _left,expression _right,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._left=_left;
			this._right=_right;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _left;
		protected expression _right;

		///<summary>
		///Нижняя граница диапазона
		///</summary>
		public expression left
		{
			get
			{
				return _left;
			}
			set
			{
				_left=value;
			}
		}

		///<summary>
		///Верхняя граница диапазона
		///</summary>
		public expression right
		{
			get
			{
				return _right;
			}
			set
			{
				_right=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			diapason copy = new diapason();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (left != null)
			{
				copy.left = (expression)left.Clone();
				copy.left.Parent = copy;
			}
			if (right != null)
			{
				copy.right = (expression)right.Clone();
				copy.right.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new diapason TypedClone()
		{
			return Clone() as diapason;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (left != null)
				left.Parent = this;
			if (right != null)
				right.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			left?.FillParentsInAllChilds();
			right?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return left;
					case 2:
						return right;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						left = (expression)value;
						break;
					case 2:
						right = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Типы индексов
	///</summary>
	[Serializable]
	public partial class indexers_types : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public indexers_types()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexers_types(List<type_definition> _indexers)
		{
			this._indexers=_indexers;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexers_types(List<type_definition> _indexers,SourceContext sc)
		{
			this._indexers=_indexers;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexers_types(type_definition_attr_list _attr_list,List<type_definition> _indexers)
		{
			this._attr_list=_attr_list;
			this._indexers=_indexers;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public indexers_types(type_definition_attr_list _attr_list,List<type_definition> _indexers,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._indexers=_indexers;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public indexers_types(type_definition elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<type_definition> _indexers=new List<type_definition>();

		///<summary>
		///Список типов индексов
		///</summary>
		public List<type_definition> indexers
		{
			get
			{
				return _indexers;
			}
			set
			{
				_indexers=value;
			}
		}


		public indexers_types Add(type_definition elem, SourceContext sc = null)
		{
			indexers.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(type_definition el)
		{
			indexers.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<type_definition> els)
		{
			indexers.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params type_definition[] els)
		{
			indexers.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(type_definition el)
		{
			var ind = indexers.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(type_definition el, type_definition newel)
		{
			indexers.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(type_definition el, IEnumerable<type_definition> newels)
		{
			indexers.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(type_definition el, type_definition newel)
		{
			indexers.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(type_definition el, IEnumerable<type_definition> newels)
		{
			indexers.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(type_definition el)
		{
			return indexers.Remove(el);
		}
		
		public void ReplaceInList(type_definition el, type_definition newel)
		{
			indexers[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(type_definition el, IEnumerable<type_definition> newels)
		{
			var ind = FindIndexInList(el);
			indexers.RemoveAt(ind);
			indexers.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<type_definition> match)
		{
			return indexers.RemoveAll(match);
		}
		
		public type_definition Last()
		{
			return indexers[indexers.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			indexers_types copy = new indexers_types();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (indexers != null)
			{
				foreach (type_definition elem in indexers)
				{
					if (elem != null)
					{
						copy.Add((type_definition)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new indexers_types TypedClone()
		{
			return Clone() as indexers_types;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (indexers != null)
			{
				foreach (var child in indexers)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			if (indexers != null)
			{
				foreach (var child in indexers)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1 + (indexers == null ? 0 : indexers.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				Int32 index_counter=ind - 1;
				if(indexers != null)
				{
					if(index_counter < indexers.Count)
					{
						return indexers[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
				Int32 index_counter=ind - 1;
				if(indexers != null)
				{
					if(index_counter < indexers.Count)
					{
						indexers[index_counter]= (type_definition)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Тип массива
	///</summary>
	[Serializable]
	public partial class array_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public array_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_type(indexers_types _indexers,type_definition _elements_type)
		{
			this._indexers=_indexers;
			this._elements_type=_elements_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_type(indexers_types _indexers,type_definition _elements_type,SourceContext sc)
		{
			this._indexers=_indexers;
			this._elements_type=_elements_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_type(type_definition_attr_list _attr_list,indexers_types _indexers,type_definition _elements_type)
		{
			this._attr_list=_attr_list;
			this._indexers=_indexers;
			this._elements_type=_elements_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_type(type_definition_attr_list _attr_list,indexers_types _indexers,type_definition _elements_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._indexers=_indexers;
			this._elements_type=_elements_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected indexers_types _indexers;
		protected type_definition _elements_type;

		///<summary>
		///Типы индексов массива
		///</summary>
		public indexers_types indexers
		{
			get
			{
				return _indexers;
			}
			set
			{
				_indexers=value;
			}
		}

		///<summary>
		///Тип элементов массива
		///</summary>
		public type_definition elements_type
		{
			get
			{
				return _elements_type;
			}
			set
			{
				_elements_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			array_type copy = new array_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (indexers != null)
			{
				copy.indexers = (indexers_types)indexers.Clone();
				copy.indexers.Parent = copy;
			}
			if (elements_type != null)
			{
				copy.elements_type = (type_definition)elements_type.Clone();
				copy.elements_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new array_type TypedClone()
		{
			return Clone() as array_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (indexers != null)
				indexers.Parent = this;
			if (elements_type != null)
				elements_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			indexers?.FillParentsInAllChilds();
			elements_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return indexers;
					case 2:
						return elements_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						indexers = (indexers_types)value;
						break;
					case 2:
						elements_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Описание меток
	///</summary>
	[Serializable]
	public partial class label_definitions : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public label_definitions()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public label_definitions(ident_list _labels)
		{
			this._labels=_labels;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public label_definitions(ident_list _labels,SourceContext sc)
		{
			this._labels=_labels;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _labels;

		///<summary>
		///Список меток
		///</summary>
		public ident_list labels
		{
			get
			{
				return _labels;
			}
			set
			{
				_labels=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			label_definitions copy = new label_definitions();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (labels != null)
			{
				copy.labels = (ident_list)labels.Clone();
				copy.labels.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new label_definitions TypedClone()
		{
			return Clone() as label_definitions;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (labels != null)
				labels.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			labels?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return labels;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						labels = (ident_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class procedure_attribute : ident
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public procedure_attribute()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_attribute(proc_attribute _attribute_type)
		{
			this._attribute_type=_attribute_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_attribute(proc_attribute _attribute_type,SourceContext sc)
		{
			this._attribute_type=_attribute_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_attribute(string _name,proc_attribute _attribute_type)
		{
			this._name=_name;
			this._attribute_type=_attribute_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_attribute(string _name,proc_attribute _attribute_type,SourceContext sc)
		{
			this._name=_name;
			this._attribute_type=_attribute_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected proc_attribute _attribute_type;

		///<summary>
		///
		///</summary>
		public proc_attribute attribute_type
		{
			get
			{
				return _attribute_type;
			}
			set
			{
				_attribute_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			procedure_attribute copy = new procedure_attribute();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			copy.attribute_type = attribute_type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new procedure_attribute TypedClone()
		{
			return Clone() as procedure_attribute;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class typed_parameters : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public typed_parameters()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typed_parameters(ident_list _idents,type_definition _vars_type,parametr_kind _param_kind,expression _inital_value)
		{
			this._idents=_idents;
			this._vars_type=_vars_type;
			this._param_kind=_param_kind;
			this._inital_value=_inital_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typed_parameters(ident_list _idents,type_definition _vars_type,parametr_kind _param_kind,expression _inital_value,SourceContext sc)
		{
			this._idents=_idents;
			this._vars_type=_vars_type;
			this._param_kind=_param_kind;
			this._inital_value=_inital_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _idents;
		protected type_definition _vars_type;
		protected parametr_kind _param_kind;
		protected expression _inital_value;

		///<summary>
		///
		///</summary>
		public ident_list idents
		{
			get
			{
				return _idents;
			}
			set
			{
				_idents=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition vars_type
		{
			get
			{
				return _vars_type;
			}
			set
			{
				_vars_type=value;
			}
		}

		///<summary>
		///
		///</summary>
		public parametr_kind param_kind
		{
			get
			{
				return _param_kind;
			}
			set
			{
				_param_kind=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression inital_value
		{
			get
			{
				return _inital_value;
			}
			set
			{
				_inital_value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			typed_parameters copy = new typed_parameters();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (idents != null)
			{
				copy.idents = (ident_list)idents.Clone();
				copy.idents.Parent = copy;
			}
			if (vars_type != null)
			{
				copy.vars_type = (type_definition)vars_type.Clone();
				copy.vars_type.Parent = copy;
			}
			copy.param_kind = param_kind;
			if (inital_value != null)
			{
				copy.inital_value = (expression)inital_value.Clone();
				copy.inital_value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new typed_parameters TypedClone()
		{
			return Clone() as typed_parameters;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (idents != null)
				idents.Parent = this;
			if (vars_type != null)
				vars_type.Parent = this;
			if (inital_value != null)
				inital_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			idents?.FillParentsInAllChilds();
			vars_type?.FillParentsInAllChilds();
			inital_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return idents;
					case 1:
						return vars_type;
					case 2:
						return inital_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						idents = (ident_list)value;
						break;
					case 1:
						vars_type = (type_definition)value;
						break;
					case 2:
						inital_value = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class formal_parameters : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public formal_parameters()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public formal_parameters(List<typed_parameters> _params_list)
		{
			this._params_list=_params_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public formal_parameters(List<typed_parameters> _params_list,SourceContext sc)
		{
			this._params_list=_params_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public formal_parameters(typed_parameters elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<typed_parameters> _params_list=new List<typed_parameters>();

		///<summary>
		///
		///</summary>
		public List<typed_parameters> params_list
		{
			get
			{
				return _params_list;
			}
			set
			{
				_params_list=value;
			}
		}


		public formal_parameters Add(typed_parameters elem, SourceContext sc = null)
		{
			params_list.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(typed_parameters el)
		{
			params_list.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<typed_parameters> els)
		{
			params_list.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params typed_parameters[] els)
		{
			params_list.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(typed_parameters el)
		{
			var ind = params_list.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(typed_parameters el, typed_parameters newel)
		{
			params_list.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(typed_parameters el, IEnumerable<typed_parameters> newels)
		{
			params_list.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(typed_parameters el, typed_parameters newel)
		{
			params_list.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(typed_parameters el, IEnumerable<typed_parameters> newels)
		{
			params_list.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(typed_parameters el)
		{
			return params_list.Remove(el);
		}
		
		public void ReplaceInList(typed_parameters el, typed_parameters newel)
		{
			params_list[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(typed_parameters el, IEnumerable<typed_parameters> newels)
		{
			var ind = FindIndexInList(el);
			params_list.RemoveAt(ind);
			params_list.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<typed_parameters> match)
		{
			return params_list.RemoveAll(match);
		}
		
		public typed_parameters Last()
		{
			return params_list[params_list.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			formal_parameters copy = new formal_parameters();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (params_list != null)
			{
				foreach (typed_parameters elem in params_list)
				{
					if (elem != null)
					{
						copy.Add((typed_parameters)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new formal_parameters TypedClone()
		{
			return Clone() as formal_parameters;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (params_list != null)
			{
				foreach (var child in params_list)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (params_list != null)
			{
				foreach (var child in params_list)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (params_list == null ? 0 : params_list.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(params_list != null)
				{
					if(index_counter < params_list.Count)
					{
						return params_list[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(params_list != null)
				{
					if(index_counter < params_list.Count)
					{
						params_list[index_counter]= (typed_parameters)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class procedure_attributes_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public procedure_attributes_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_attributes_list(List<procedure_attribute> _proc_attributes)
		{
			this._proc_attributes=_proc_attributes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_attributes_list(List<procedure_attribute> _proc_attributes,SourceContext sc)
		{
			this._proc_attributes=_proc_attributes;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public procedure_attributes_list(procedure_attribute elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<procedure_attribute> _proc_attributes=new List<procedure_attribute>();

		///<summary>
		///
		///</summary>
		public List<procedure_attribute> proc_attributes
		{
			get
			{
				return _proc_attributes;
			}
			set
			{
				_proc_attributes=value;
			}
		}


		public procedure_attributes_list Add(procedure_attribute elem, SourceContext sc = null)
		{
			proc_attributes.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(procedure_attribute el)
		{
			proc_attributes.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<procedure_attribute> els)
		{
			proc_attributes.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params procedure_attribute[] els)
		{
			proc_attributes.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(procedure_attribute el)
		{
			var ind = proc_attributes.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(procedure_attribute el, procedure_attribute newel)
		{
			proc_attributes.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(procedure_attribute el, IEnumerable<procedure_attribute> newels)
		{
			proc_attributes.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(procedure_attribute el, procedure_attribute newel)
		{
			proc_attributes.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(procedure_attribute el, IEnumerable<procedure_attribute> newels)
		{
			proc_attributes.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(procedure_attribute el)
		{
			return proc_attributes.Remove(el);
		}
		
		public void ReplaceInList(procedure_attribute el, procedure_attribute newel)
		{
			proc_attributes[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(procedure_attribute el, IEnumerable<procedure_attribute> newels)
		{
			var ind = FindIndexInList(el);
			proc_attributes.RemoveAt(ind);
			proc_attributes.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<procedure_attribute> match)
		{
			return proc_attributes.RemoveAll(match);
		}
		
		public procedure_attribute Last()
		{
			return proc_attributes[proc_attributes.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			procedure_attributes_list copy = new procedure_attributes_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (proc_attributes != null)
			{
				foreach (procedure_attribute elem in proc_attributes)
				{
					if (elem != null)
					{
						copy.Add((procedure_attribute)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new procedure_attributes_list TypedClone()
		{
			return Clone() as procedure_attributes_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (proc_attributes != null)
			{
				foreach (var child in proc_attributes)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (proc_attributes != null)
			{
				foreach (var child in proc_attributes)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (proc_attributes == null ? 0 : proc_attributes.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(proc_attributes != null)
				{
					if(index_counter < proc_attributes.Count)
					{
						return proc_attributes[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(proc_attributes != null)
				{
					if(index_counter < proc_attributes.Count)
					{
						proc_attributes[index_counter]= (procedure_attribute)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class procedure_header : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public procedure_header()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_header(formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs)
		{
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_header(formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs,SourceContext sc)
		{
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_header(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_header(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected formal_parameters _parameters;
		protected procedure_attributes_list _proc_attributes;
		protected method_name _name;
		protected bool _of_object;
		protected bool _class_keyword;
		protected ident_list _template_args;
		protected where_definition_list _where_defs;

		///<summary>
		///
		///</summary>
		public formal_parameters parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters=value;
			}
		}

		///<summary>
		///
		///</summary>
		public procedure_attributes_list proc_attributes
		{
			get
			{
				return _proc_attributes;
			}
			set
			{
				_proc_attributes=value;
			}
		}

		///<summary>
		///
		///</summary>
		public method_name name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public bool of_object
		{
			get
			{
				return _of_object;
			}
			set
			{
				_of_object=value;
			}
		}

		///<summary>
		///class procedure...
		///</summary>
		public bool class_keyword
		{
			get
			{
				return _class_keyword;
			}
			set
			{
				_class_keyword=value;
			}
		}

		///<summary>
		///
		///</summary>
		public ident_list template_args
		{
			get
			{
				return _template_args;
			}
			set
			{
				_template_args=value;
			}
		}

		///<summary>
		///
		///</summary>
		public where_definition_list where_defs
		{
			get
			{
				return _where_defs;
			}
			set
			{
				_where_defs=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			procedure_header copy = new procedure_header();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (parameters != null)
			{
				copy.parameters = (formal_parameters)parameters.Clone();
				copy.parameters.Parent = copy;
			}
			if (proc_attributes != null)
			{
				copy.proc_attributes = (procedure_attributes_list)proc_attributes.Clone();
				copy.proc_attributes.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (method_name)name.Clone();
				copy.name.Parent = copy;
			}
			copy.of_object = of_object;
			copy.class_keyword = class_keyword;
			if (template_args != null)
			{
				copy.template_args = (ident_list)template_args.Clone();
				copy.template_args.Parent = copy;
			}
			if (where_defs != null)
			{
				copy.where_defs = (where_definition_list)where_defs.Clone();
				copy.where_defs.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new procedure_header TypedClone()
		{
			return Clone() as procedure_header;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (parameters != null)
				parameters.Parent = this;
			if (proc_attributes != null)
				proc_attributes.Parent = this;
			if (name != null)
				name.Parent = this;
			if (template_args != null)
				template_args.Parent = this;
			if (where_defs != null)
				where_defs.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			parameters?.FillParentsInAllChilds();
			proc_attributes?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
			template_args?.FillParentsInAllChilds();
			where_defs?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return parameters;
					case 2:
						return proc_attributes;
					case 3:
						return name;
					case 4:
						return template_args;
					case 5:
						return where_defs;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						parameters = (formal_parameters)value;
						break;
					case 2:
						proc_attributes = (procedure_attributes_list)value;
						break;
					case 3:
						name = (method_name)value;
						break;
					case 4:
						template_args = (ident_list)value;
						break;
					case 5:
						where_defs = (where_definition_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class function_header : procedure_header
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public function_header()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_header(type_definition _return_type)
		{
			this._return_type=_return_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_header(type_definition _return_type,SourceContext sc)
		{
			this._return_type=_return_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_header(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs,type_definition _return_type)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			this._return_type=_return_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_header(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs,type_definition _return_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			this._return_type=_return_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _return_type;

		///<summary>
		///
		///</summary>
		public type_definition return_type
		{
			get
			{
				return _return_type;
			}
			set
			{
				_return_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			function_header copy = new function_header();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (parameters != null)
			{
				copy.parameters = (formal_parameters)parameters.Clone();
				copy.parameters.Parent = copy;
			}
			if (proc_attributes != null)
			{
				copy.proc_attributes = (procedure_attributes_list)proc_attributes.Clone();
				copy.proc_attributes.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (method_name)name.Clone();
				copy.name.Parent = copy;
			}
			copy.of_object = of_object;
			copy.class_keyword = class_keyword;
			if (template_args != null)
			{
				copy.template_args = (ident_list)template_args.Clone();
				copy.template_args.Parent = copy;
			}
			if (where_defs != null)
			{
				copy.where_defs = (where_definition_list)where_defs.Clone();
				copy.where_defs.Parent = copy;
			}
			if (return_type != null)
			{
				copy.return_type = (type_definition)return_type.Clone();
				copy.return_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new function_header TypedClone()
		{
			return Clone() as function_header;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (parameters != null)
				parameters.Parent = this;
			if (proc_attributes != null)
				proc_attributes.Parent = this;
			if (name != null)
				name.Parent = this;
			if (template_args != null)
				template_args.Parent = this;
			if (where_defs != null)
				where_defs.Parent = this;
			if (return_type != null)
				return_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			parameters?.FillParentsInAllChilds();
			proc_attributes?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
			template_args?.FillParentsInAllChilds();
			where_defs?.FillParentsInAllChilds();
			return_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 7;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 7;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return parameters;
					case 2:
						return proc_attributes;
					case 3:
						return name;
					case 4:
						return template_args;
					case 5:
						return where_defs;
					case 6:
						return return_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						parameters = (formal_parameters)value;
						break;
					case 2:
						proc_attributes = (procedure_attributes_list)value;
						break;
					case 3:
						name = (method_name)value;
						break;
					case 4:
						template_args = (ident_list)value;
						break;
					case 5:
						where_defs = (where_definition_list)value;
						break;
					case 6:
						return_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class procedure_definition : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public procedure_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_definition(procedure_header _proc_header,proc_block _proc_body,bool _is_short_definition)
		{
			this._proc_header=_proc_header;
			this._proc_body=_proc_body;
			this._is_short_definition=_is_short_definition;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_definition(procedure_header _proc_header,proc_block _proc_body,bool _is_short_definition,SourceContext sc)
		{
			this._proc_header=_proc_header;
			this._proc_body=_proc_body;
			this._is_short_definition=_is_short_definition;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected procedure_header _proc_header;
		protected proc_block _proc_body;
		protected bool _is_short_definition;

		///<summary>
		///
		///</summary>
		public procedure_header proc_header
		{
			get
			{
				return _proc_header;
			}
			set
			{
				_proc_header=value;
			}
		}

		///<summary>
		///
		///</summary>
		public proc_block proc_body
		{
			get
			{
				return _proc_body;
			}
			set
			{
				_proc_body=value;
			}
		}

		///<summary>
		///
		///</summary>
		public bool is_short_definition
		{
			get
			{
				return _is_short_definition;
			}
			set
			{
				_is_short_definition=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			procedure_definition copy = new procedure_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (proc_header != null)
			{
				copy.proc_header = (procedure_header)proc_header.Clone();
				copy.proc_header.Parent = copy;
			}
			if (proc_body != null)
			{
				copy.proc_body = (proc_block)proc_body.Clone();
				copy.proc_body.Parent = copy;
			}
			copy.is_short_definition = is_short_definition;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new procedure_definition TypedClone()
		{
			return Clone() as procedure_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (proc_header != null)
				proc_header.Parent = this;
			if (proc_body != null)
				proc_body.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			proc_header?.FillParentsInAllChilds();
			proc_body?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return proc_header;
					case 1:
						return proc_body;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						proc_header = (procedure_header)value;
						break;
					case 1:
						proc_body = (proc_block)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class type_declaration : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public type_declaration()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_declaration(ident _type_name,type_definition _type_def)
		{
			this._type_name=_type_name;
			this._type_def=_type_def;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_declaration(ident _type_name,type_definition _type_def,SourceContext sc)
		{
			this._type_name=_type_name;
			this._type_def=_type_def;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _type_name;
		protected type_definition _type_def;

		///<summary>
		///
		///</summary>
		public ident type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition type_def
		{
			get
			{
				return _type_def;
			}
			set
			{
				_type_def=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			type_declaration copy = new type_declaration();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (ident)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			if (type_def != null)
			{
				copy.type_def = (type_definition)type_def.Clone();
				copy.type_def.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new type_declaration TypedClone()
		{
			return Clone() as type_declaration;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
			if (type_def != null)
				type_def.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
			type_def?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return type_name;
					case 1:
						return type_def;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						type_name = (ident)value;
						break;
					case 1:
						type_def = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Список определений типов
	///</summary>
	[Serializable]
	public partial class type_declarations : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public type_declarations()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_declarations(List<type_declaration> _types_decl)
		{
			this._types_decl=_types_decl;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_declarations(List<type_declaration> _types_decl,SourceContext sc)
		{
			this._types_decl=_types_decl;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public type_declarations(type_declaration elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<type_declaration> _types_decl=new List<type_declaration>();

		///<summary>
		///
		///</summary>
		public List<type_declaration> types_decl
		{
			get
			{
				return _types_decl;
			}
			set
			{
				_types_decl=value;
			}
		}


		public type_declarations Add(type_declaration elem, SourceContext sc = null)
		{
			types_decl.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(type_declaration el)
		{
			types_decl.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<type_declaration> els)
		{
			types_decl.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params type_declaration[] els)
		{
			types_decl.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(type_declaration el)
		{
			var ind = types_decl.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(type_declaration el, type_declaration newel)
		{
			types_decl.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(type_declaration el, IEnumerable<type_declaration> newels)
		{
			types_decl.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(type_declaration el, type_declaration newel)
		{
			types_decl.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(type_declaration el, IEnumerable<type_declaration> newels)
		{
			types_decl.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(type_declaration el)
		{
			return types_decl.Remove(el);
		}
		
		public void ReplaceInList(type_declaration el, type_declaration newel)
		{
			types_decl[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(type_declaration el, IEnumerable<type_declaration> newels)
		{
			var ind = FindIndexInList(el);
			types_decl.RemoveAt(ind);
			types_decl.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<type_declaration> match)
		{
			return types_decl.RemoveAll(match);
		}
		
		public type_declaration Last()
		{
			return types_decl[types_decl.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			type_declarations copy = new type_declarations();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (types_decl != null)
			{
				foreach (type_declaration elem in types_decl)
				{
					if (elem != null)
					{
						copy.Add((type_declaration)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new type_declarations TypedClone()
		{
			return Clone() as type_declarations;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (types_decl != null)
			{
				foreach (var child in types_decl)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (types_decl != null)
			{
				foreach (var child in types_decl)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (types_decl == null ? 0 : types_decl.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(types_decl != null)
				{
					if(index_counter < types_decl.Count)
					{
						return types_decl[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(types_decl != null)
				{
					if(index_counter < types_decl.Count)
					{
						types_decl[index_counter]= (type_declaration)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class simple_const_definition : const_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public simple_const_definition()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public simple_const_definition(ident _const_name,expression _const_value)
		{
			this._const_name=_const_name;
			this._const_value=_const_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public simple_const_definition(ident _const_name,expression _const_value,SourceContext sc)
		{
			this._const_name=_const_name;
			this._const_value=_const_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			simple_const_definition copy = new simple_const_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (const_name != null)
			{
				copy.const_name = (ident)const_name.Clone();
				copy.const_name.Parent = copy;
			}
			if (const_value != null)
			{
				copy.const_value = (expression)const_value.Clone();
				copy.const_value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new simple_const_definition TypedClone()
		{
			return Clone() as simple_const_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (const_name != null)
				const_name.Parent = this;
			if (const_value != null)
				const_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			const_name?.FillParentsInAllChilds();
			const_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return const_name;
					case 1:
						return const_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						const_name = (ident)value;
						break;
					case 1:
						const_value = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class typed_const_definition : const_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public typed_const_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typed_const_definition(type_definition _const_type)
		{
			this._const_type=_const_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typed_const_definition(type_definition _const_type,SourceContext sc)
		{
			this._const_type=_const_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typed_const_definition(ident _const_name,expression _const_value,type_definition _const_type)
		{
			this._const_name=_const_name;
			this._const_value=_const_value;
			this._const_type=_const_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typed_const_definition(ident _const_name,expression _const_value,type_definition _const_type,SourceContext sc)
		{
			this._const_name=_const_name;
			this._const_value=_const_value;
			this._const_type=_const_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _const_type;

		///<summary>
		///
		///</summary>
		public type_definition const_type
		{
			get
			{
				return _const_type;
			}
			set
			{
				_const_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			typed_const_definition copy = new typed_const_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (const_name != null)
			{
				copy.const_name = (ident)const_name.Clone();
				copy.const_name.Parent = copy;
			}
			if (const_value != null)
			{
				copy.const_value = (expression)const_value.Clone();
				copy.const_value.Parent = copy;
			}
			if (const_type != null)
			{
				copy.const_type = (type_definition)const_type.Clone();
				copy.const_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new typed_const_definition TypedClone()
		{
			return Clone() as typed_const_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (const_name != null)
				const_name.Parent = this;
			if (const_value != null)
				const_value.Parent = this;
			if (const_type != null)
				const_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			const_name?.FillParentsInAllChilds();
			const_value?.FillParentsInAllChilds();
			const_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return const_name;
					case 1:
						return const_value;
					case 2:
						return const_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						const_name = (ident)value;
						break;
					case 1:
						const_value = (expression)value;
						break;
					case 2:
						const_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class const_definition : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public const_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public const_definition(ident _const_name,expression _const_value)
		{
			this._const_name=_const_name;
			this._const_value=_const_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public const_definition(ident _const_name,expression _const_value,SourceContext sc)
		{
			this._const_name=_const_name;
			this._const_value=_const_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _const_name;
		protected expression _const_value;

		///<summary>
		///
		///</summary>
		public ident const_name
		{
			get
			{
				return _const_name;
			}
			set
			{
				_const_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression const_value
		{
			get
			{
				return _const_value;
			}
			set
			{
				_const_value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			const_definition copy = new const_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (const_name != null)
			{
				copy.const_name = (ident)const_name.Clone();
				copy.const_name.Parent = copy;
			}
			if (const_value != null)
			{
				copy.const_value = (expression)const_value.Clone();
				copy.const_value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new const_definition TypedClone()
		{
			return Clone() as const_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (const_name != null)
				const_name.Parent = this;
			if (const_value != null)
				const_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			const_name?.FillParentsInAllChilds();
			const_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return const_name;
					case 1:
						return const_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						const_name = (ident)value;
						break;
					case 1:
						const_value = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class consts_definitions_list : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public consts_definitions_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public consts_definitions_list(List<const_definition> _const_defs)
		{
			this._const_defs=_const_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public consts_definitions_list(List<const_definition> _const_defs,SourceContext sc)
		{
			this._const_defs=_const_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public consts_definitions_list(const_definition elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<const_definition> _const_defs=new List<const_definition>();

		///<summary>
		///
		///</summary>
		public List<const_definition> const_defs
		{
			get
			{
				return _const_defs;
			}
			set
			{
				_const_defs=value;
			}
		}


		public consts_definitions_list Add(const_definition elem, SourceContext sc = null)
		{
			const_defs.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(const_definition el)
		{
			const_defs.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<const_definition> els)
		{
			const_defs.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params const_definition[] els)
		{
			const_defs.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(const_definition el)
		{
			var ind = const_defs.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(const_definition el, const_definition newel)
		{
			const_defs.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(const_definition el, IEnumerable<const_definition> newels)
		{
			const_defs.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(const_definition el, const_definition newel)
		{
			const_defs.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(const_definition el, IEnumerable<const_definition> newels)
		{
			const_defs.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(const_definition el)
		{
			return const_defs.Remove(el);
		}
		
		public void ReplaceInList(const_definition el, const_definition newel)
		{
			const_defs[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(const_definition el, IEnumerable<const_definition> newels)
		{
			var ind = FindIndexInList(el);
			const_defs.RemoveAt(ind);
			const_defs.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<const_definition> match)
		{
			return const_defs.RemoveAll(match);
		}
		
		public const_definition Last()
		{
			return const_defs[const_defs.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			consts_definitions_list copy = new consts_definitions_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (const_defs != null)
			{
				foreach (const_definition elem in const_defs)
				{
					if (elem != null)
					{
						copy.Add((const_definition)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new consts_definitions_list TypedClone()
		{
			return Clone() as consts_definitions_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (const_defs != null)
			{
				foreach (var child in const_defs)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (const_defs != null)
			{
				foreach (var child in const_defs)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (const_defs == null ? 0 : const_defs.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(const_defs != null)
				{
					if(index_counter < const_defs.Count)
					{
						return const_defs[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(const_defs != null)
				{
					if(index_counter < const_defs.Count)
					{
						const_defs[index_counter]= (const_definition)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class unit_name : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public unit_name()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_name(ident _idunit_name,UnitHeaderKeyword _HeaderKeyword)
		{
			this._idunit_name=_idunit_name;
			this._HeaderKeyword=_HeaderKeyword;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_name(ident _idunit_name,UnitHeaderKeyword _HeaderKeyword,SourceContext sc)
		{
			this._idunit_name=_idunit_name;
			this._HeaderKeyword=_HeaderKeyword;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _idunit_name;
		protected UnitHeaderKeyword _HeaderKeyword;

		///<summary>
		///
		///</summary>
		public ident idunit_name
		{
			get
			{
				return _idunit_name;
			}
			set
			{
				_idunit_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public UnitHeaderKeyword HeaderKeyword
		{
			get
			{
				return _HeaderKeyword;
			}
			set
			{
				_HeaderKeyword=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			unit_name copy = new unit_name();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (idunit_name != null)
			{
				copy.idunit_name = (ident)idunit_name.Clone();
				copy.idunit_name.Parent = copy;
			}
			copy.HeaderKeyword = HeaderKeyword;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new unit_name TypedClone()
		{
			return Clone() as unit_name;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (idunit_name != null)
				idunit_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			idunit_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return idunit_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						idunit_name = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class unit_or_namespace : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public unit_or_namespace()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_or_namespace(ident_list _name)
		{
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_or_namespace(ident_list _name,SourceContext sc)
		{
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _name;

		///<summary>
		///
		///</summary>
		public ident_list name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			unit_or_namespace copy = new unit_or_namespace();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (name != null)
			{
				copy.name = (ident_list)name.Clone();
				copy.name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new unit_or_namespace TypedClone()
		{
			return Clone() as unit_or_namespace;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (name != null)
				name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						name = (ident_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class uses_unit_in : unit_or_namespace
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public uses_unit_in()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_unit_in(string_const _in_file)
		{
			this._in_file=_in_file;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_unit_in(string_const _in_file,SourceContext sc)
		{
			this._in_file=_in_file;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_unit_in(ident_list _name,string_const _in_file)
		{
			this._name=_name;
			this._in_file=_in_file;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_unit_in(ident_list _name,string_const _in_file,SourceContext sc)
		{
			this._name=_name;
			this._in_file=_in_file;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected string_const _in_file;

		///<summary>
		///
		///</summary>
		public string_const in_file
		{
			get
			{
				return _in_file;
			}
			set
			{
				_in_file=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			uses_unit_in copy = new uses_unit_in();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (name != null)
			{
				copy.name = (ident_list)name.Clone();
				copy.name.Parent = copy;
			}
			if (in_file != null)
			{
				copy.in_file = (string_const)in_file.Clone();
				copy.in_file.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new uses_unit_in TypedClone()
		{
			return Clone() as uses_unit_in;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (name != null)
				name.Parent = this;
			if (in_file != null)
				in_file.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			name?.FillParentsInAllChilds();
			in_file?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return name;
					case 1:
						return in_file;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						name = (ident_list)value;
						break;
					case 1:
						in_file = (string_const)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class uses_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public uses_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_list(List<unit_or_namespace> _units)
		{
			this._units=_units;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_list(List<unit_or_namespace> _units,SourceContext sc)
		{
			this._units=_units;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public uses_list(unit_or_namespace elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<unit_or_namespace> _units=new List<unit_or_namespace>();

		///<summary>
		///
		///</summary>
		public List<unit_or_namespace> units
		{
			get
			{
				return _units;
			}
			set
			{
				_units=value;
			}
		}


		public uses_list Add(unit_or_namespace elem, SourceContext sc = null)
		{
			units.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(unit_or_namespace el)
		{
			units.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<unit_or_namespace> els)
		{
			units.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params unit_or_namespace[] els)
		{
			units.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(unit_or_namespace el)
		{
			var ind = units.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(unit_or_namespace el, unit_or_namespace newel)
		{
			units.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(unit_or_namespace el, IEnumerable<unit_or_namespace> newels)
		{
			units.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(unit_or_namespace el, unit_or_namespace newel)
		{
			units.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(unit_or_namespace el, IEnumerable<unit_or_namespace> newels)
		{
			units.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(unit_or_namespace el)
		{
			return units.Remove(el);
		}
		
		public void ReplaceInList(unit_or_namespace el, unit_or_namespace newel)
		{
			units[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(unit_or_namespace el, IEnumerable<unit_or_namespace> newels)
		{
			var ind = FindIndexInList(el);
			units.RemoveAt(ind);
			units.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<unit_or_namespace> match)
		{
			return units.RemoveAll(match);
		}
		
		public unit_or_namespace Last()
		{
			return units[units.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			uses_list copy = new uses_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (units != null)
			{
				foreach (unit_or_namespace elem in units)
				{
					if (elem != null)
					{
						copy.Add((unit_or_namespace)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new uses_list TypedClone()
		{
			return Clone() as uses_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (units != null)
			{
				foreach (var child in units)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (units != null)
			{
				foreach (var child in units)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (units == null ? 0 : units.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(units != null)
				{
					if(index_counter < units.Count)
					{
						return units[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(units != null)
				{
					if(index_counter < units.Count)
					{
						units[index_counter]= (unit_or_namespace)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class program_body : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public program_body()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_body(uses_list _used_units,declarations _program_definitions,statement_list _program_code,using_list _using_list)
		{
			this._used_units=_used_units;
			this._program_definitions=_program_definitions;
			this._program_code=_program_code;
			this._using_list=_using_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_body(uses_list _used_units,declarations _program_definitions,statement_list _program_code,using_list _using_list,SourceContext sc)
		{
			this._used_units=_used_units;
			this._program_definitions=_program_definitions;
			this._program_code=_program_code;
			this._using_list=_using_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected uses_list _used_units;
		protected declarations _program_definitions;
		protected statement_list _program_code;
		protected using_list _using_list;

		///<summary>
		///
		///</summary>
		public uses_list used_units
		{
			get
			{
				return _used_units;
			}
			set
			{
				_used_units=value;
			}
		}

		///<summary>
		///
		///</summary>
		public declarations program_definitions
		{
			get
			{
				return _program_definitions;
			}
			set
			{
				_program_definitions=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement_list program_code
		{
			get
			{
				return _program_code;
			}
			set
			{
				_program_code=value;
			}
		}

		///<summary>
		///
		///</summary>
		public using_list using_list
		{
			get
			{
				return _using_list;
			}
			set
			{
				_using_list=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			program_body copy = new program_body();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (used_units != null)
			{
				copy.used_units = (uses_list)used_units.Clone();
				copy.used_units.Parent = copy;
			}
			if (program_definitions != null)
			{
				copy.program_definitions = (declarations)program_definitions.Clone();
				copy.program_definitions.Parent = copy;
			}
			if (program_code != null)
			{
				copy.program_code = (statement_list)program_code.Clone();
				copy.program_code.Parent = copy;
			}
			if (using_list != null)
			{
				copy.using_list = (using_list)using_list.Clone();
				copy.using_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new program_body TypedClone()
		{
			return Clone() as program_body;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (used_units != null)
				used_units.Parent = this;
			if (program_definitions != null)
				program_definitions.Parent = this;
			if (program_code != null)
				program_code.Parent = this;
			if (using_list != null)
				using_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			used_units?.FillParentsInAllChilds();
			program_definitions?.FillParentsInAllChilds();
			program_code?.FillParentsInAllChilds();
			using_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return used_units;
					case 1:
						return program_definitions;
					case 2:
						return program_code;
					case 3:
						return using_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						used_units = (uses_list)value;
						break;
					case 1:
						program_definitions = (declarations)value;
						break;
					case 2:
						program_code = (statement_list)value;
						break;
					case 3:
						using_list = (using_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class compilation_unit : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public compilation_unit()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compilation_unit(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compilation_unit(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language,SourceContext sc)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public compilation_unit(compiler_directive elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected string _file_name;
		protected List<compiler_directive> _compiler_directives=new List<compiler_directive>();
		protected LanguageId _Language;

		///<summary>
		///
		///</summary>
		public string file_name
		{
			get
			{
				return _file_name;
			}
			set
			{
				_file_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public List<compiler_directive> compiler_directives
		{
			get
			{
				return _compiler_directives;
			}
			set
			{
				_compiler_directives=value;
			}
		}

		///<summary>
		///
		///</summary>
		public LanguageId Language
		{
			get
			{
				return _Language;
			}
			set
			{
				_Language=value;
			}
		}


		public compilation_unit Add(compiler_directive elem, SourceContext sc = null)
		{
			compiler_directives.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(compiler_directive el)
		{
			compiler_directives.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<compiler_directive> els)
		{
			compiler_directives.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params compiler_directive[] els)
		{
			compiler_directives.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(compiler_directive el)
		{
			var ind = compiler_directives.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(compiler_directive el, compiler_directive newel)
		{
			compiler_directives.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(compiler_directive el, IEnumerable<compiler_directive> newels)
		{
			compiler_directives.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(compiler_directive el, compiler_directive newel)
		{
			compiler_directives.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(compiler_directive el, IEnumerable<compiler_directive> newels)
		{
			compiler_directives.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(compiler_directive el)
		{
			return compiler_directives.Remove(el);
		}
		
		public void ReplaceInList(compiler_directive el, compiler_directive newel)
		{
			compiler_directives[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(compiler_directive el, IEnumerable<compiler_directive> newels)
		{
			var ind = FindIndexInList(el);
			compiler_directives.RemoveAt(ind);
			compiler_directives.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<compiler_directive> match)
		{
			return compiler_directives.RemoveAll(match);
		}
		
		public compiler_directive Last()
		{
			return compiler_directives[compiler_directives.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			compilation_unit copy = new compilation_unit();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.file_name = file_name;
			if (compiler_directives != null)
			{
				foreach (compiler_directive elem in compiler_directives)
				{
					if (elem != null)
					{
						copy.Add((compiler_directive)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.Language = Language;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new compilation_unit TypedClone()
		{
			return Clone() as compilation_unit;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (compiler_directives == null ? 0 : compiler_directives.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						return compiler_directives[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						compiler_directives[index_counter]= (compiler_directive)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class unit_module : compilation_unit
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public unit_module()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_module(unit_name _unit_name,interface_node _interface_part,implementation_node _implementation_part,statement_list _initialization_part,statement_list _finalization_part,attribute_list _attributes)
		{
			this._unit_name=_unit_name;
			this._interface_part=_interface_part;
			this._implementation_part=_implementation_part;
			this._initialization_part=_initialization_part;
			this._finalization_part=_finalization_part;
			this._attributes=_attributes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_module(unit_name _unit_name,interface_node _interface_part,implementation_node _implementation_part,statement_list _initialization_part,statement_list _finalization_part,attribute_list _attributes,SourceContext sc)
		{
			this._unit_name=_unit_name;
			this._interface_part=_interface_part;
			this._implementation_part=_implementation_part;
			this._initialization_part=_initialization_part;
			this._finalization_part=_finalization_part;
			this._attributes=_attributes;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_module(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language,unit_name _unit_name,interface_node _interface_part,implementation_node _implementation_part,statement_list _initialization_part,statement_list _finalization_part,attribute_list _attributes)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			this._unit_name=_unit_name;
			this._interface_part=_interface_part;
			this._implementation_part=_implementation_part;
			this._initialization_part=_initialization_part;
			this._finalization_part=_finalization_part;
			this._attributes=_attributes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unit_module(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language,unit_name _unit_name,interface_node _interface_part,implementation_node _implementation_part,statement_list _initialization_part,statement_list _finalization_part,attribute_list _attributes,SourceContext sc)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			this._unit_name=_unit_name;
			this._interface_part=_interface_part;
			this._implementation_part=_implementation_part;
			this._initialization_part=_initialization_part;
			this._finalization_part=_finalization_part;
			this._attributes=_attributes;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected unit_name _unit_name;
		protected interface_node _interface_part;
		protected implementation_node _implementation_part;
		protected statement_list _initialization_part;
		protected statement_list _finalization_part;
		protected attribute_list _attributes;

		///<summary>
		///
		///</summary>
		public unit_name unit_name
		{
			get
			{
				return _unit_name;
			}
			set
			{
				_unit_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public interface_node interface_part
		{
			get
			{
				return _interface_part;
			}
			set
			{
				_interface_part=value;
			}
		}

		///<summary>
		///
		///</summary>
		public implementation_node implementation_part
		{
			get
			{
				return _implementation_part;
			}
			set
			{
				_implementation_part=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement_list initialization_part
		{
			get
			{
				return _initialization_part;
			}
			set
			{
				_initialization_part=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement_list finalization_part
		{
			get
			{
				return _finalization_part;
			}
			set
			{
				_finalization_part=value;
			}
		}

		///<summary>
		///
		///</summary>
		public attribute_list attributes
		{
			get
			{
				return _attributes;
			}
			set
			{
				_attributes=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			unit_module copy = new unit_module();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.file_name = file_name;
			if (compiler_directives != null)
			{
				foreach (compiler_directive elem in compiler_directives)
				{
					if (elem != null)
					{
						copy.Add((compiler_directive)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.Language = Language;
			if (unit_name != null)
			{
				copy.unit_name = (unit_name)unit_name.Clone();
				copy.unit_name.Parent = copy;
			}
			if (interface_part != null)
			{
				copy.interface_part = (interface_node)interface_part.Clone();
				copy.interface_part.Parent = copy;
			}
			if (implementation_part != null)
			{
				copy.implementation_part = (implementation_node)implementation_part.Clone();
				copy.implementation_part.Parent = copy;
			}
			if (initialization_part != null)
			{
				copy.initialization_part = (statement_list)initialization_part.Clone();
				copy.initialization_part.Parent = copy;
			}
			if (finalization_part != null)
			{
				copy.finalization_part = (statement_list)finalization_part.Clone();
				copy.finalization_part.Parent = copy;
			}
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new unit_module TypedClone()
		{
			return Clone() as unit_module;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					if (child != null)
						child.Parent = this;
			}
			if (unit_name != null)
				unit_name.Parent = this;
			if (interface_part != null)
				interface_part.Parent = this;
			if (implementation_part != null)
				implementation_part.Parent = this;
			if (initialization_part != null)
				initialization_part.Parent = this;
			if (finalization_part != null)
				finalization_part.Parent = this;
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					child?.FillParentsInAllChilds();
			}
			unit_name?.FillParentsInAllChilds();
			interface_part?.FillParentsInAllChilds();
			implementation_part?.FillParentsInAllChilds();
			initialization_part?.FillParentsInAllChilds();
			finalization_part?.FillParentsInAllChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 6 + (compiler_directives == null ? 0 : compiler_directives.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return unit_name;
					case 1:
						return interface_part;
					case 2:
						return implementation_part;
					case 3:
						return initialization_part;
					case 4:
						return finalization_part;
					case 5:
						return attributes;
				}
				Int32 index_counter=ind - 6;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						return compiler_directives[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						unit_name = (unit_name)value;
						break;
					case 1:
						interface_part = (interface_node)value;
						break;
					case 2:
						implementation_part = (implementation_node)value;
						break;
					case 3:
						initialization_part = (statement_list)value;
						break;
					case 4:
						finalization_part = (statement_list)value;
						break;
					case 5:
						attributes = (attribute_list)value;
						break;
				}
				Int32 index_counter=ind - 6;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						compiler_directives[index_counter]= (compiler_directive)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class program_module : compilation_unit
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public program_module()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_module(program_name _program_name,uses_list _used_units,block _program_block,using_list _using_namespaces)
		{
			this._program_name=_program_name;
			this._used_units=_used_units;
			this._program_block=_program_block;
			this._using_namespaces=_using_namespaces;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_module(program_name _program_name,uses_list _used_units,block _program_block,using_list _using_namespaces,SourceContext sc)
		{
			this._program_name=_program_name;
			this._used_units=_used_units;
			this._program_block=_program_block;
			this._using_namespaces=_using_namespaces;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_module(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language,program_name _program_name,uses_list _used_units,block _program_block,using_list _using_namespaces)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			this._program_name=_program_name;
			this._used_units=_used_units;
			this._program_block=_program_block;
			this._using_namespaces=_using_namespaces;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public program_module(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language,program_name _program_name,uses_list _used_units,block _program_block,using_list _using_namespaces,SourceContext sc)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			this._program_name=_program_name;
			this._used_units=_used_units;
			this._program_block=_program_block;
			this._using_namespaces=_using_namespaces;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected program_name _program_name;
		protected uses_list _used_units;
		protected block _program_block;
		protected using_list _using_namespaces;

		///<summary>
		///
		///</summary>
		public program_name program_name
		{
			get
			{
				return _program_name;
			}
			set
			{
				_program_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public uses_list used_units
		{
			get
			{
				return _used_units;
			}
			set
			{
				_used_units=value;
			}
		}

		///<summary>
		///
		///</summary>
		public block program_block
		{
			get
			{
				return _program_block;
			}
			set
			{
				_program_block=value;
			}
		}

		///<summary>
		///
		///</summary>
		public using_list using_namespaces
		{
			get
			{
				return _using_namespaces;
			}
			set
			{
				_using_namespaces=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			program_module copy = new program_module();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.file_name = file_name;
			if (compiler_directives != null)
			{
				foreach (compiler_directive elem in compiler_directives)
				{
					if (elem != null)
					{
						copy.Add((compiler_directive)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.Language = Language;
			if (program_name != null)
			{
				copy.program_name = (program_name)program_name.Clone();
				copy.program_name.Parent = copy;
			}
			if (used_units != null)
			{
				copy.used_units = (uses_list)used_units.Clone();
				copy.used_units.Parent = copy;
			}
			if (program_block != null)
			{
				copy.program_block = (block)program_block.Clone();
				copy.program_block.Parent = copy;
			}
			if (using_namespaces != null)
			{
				copy.using_namespaces = (using_list)using_namespaces.Clone();
				copy.using_namespaces.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new program_module TypedClone()
		{
			return Clone() as program_module;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					if (child != null)
						child.Parent = this;
			}
			if (program_name != null)
				program_name.Parent = this;
			if (used_units != null)
				used_units.Parent = this;
			if (program_block != null)
				program_block.Parent = this;
			if (using_namespaces != null)
				using_namespaces.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					child?.FillParentsInAllChilds();
			}
			program_name?.FillParentsInAllChilds();
			used_units?.FillParentsInAllChilds();
			program_block?.FillParentsInAllChilds();
			using_namespaces?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 4 + (compiler_directives == null ? 0 : compiler_directives.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return program_name;
					case 1:
						return used_units;
					case 2:
						return program_block;
					case 3:
						return using_namespaces;
				}
				Int32 index_counter=ind - 4;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						return compiler_directives[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						program_name = (program_name)value;
						break;
					case 1:
						used_units = (uses_list)value;
						break;
					case 2:
						program_block = (block)value;
						break;
					case 3:
						using_namespaces = (using_list)value;
						break;
				}
				Int32 index_counter=ind - 4;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						compiler_directives[index_counter]= (compiler_directive)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class hex_constant : int64_const
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public hex_constant()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public hex_constant(Int64 _val)
		{
			this._val=_val;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public hex_constant(Int64 _val,SourceContext sc)
		{
			this._val=_val;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			hex_constant copy = new hex_constant();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.val = val;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new hex_constant TypedClone()
		{
			return Clone() as hex_constant;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class get_address : addressed_value_funcname
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public get_address()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public get_address(addressed_value _address_of)
		{
			this._address_of=_address_of;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public get_address(addressed_value _address_of,SourceContext sc)
		{
			this._address_of=_address_of;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _address_of;

		///<summary>
		///
		///</summary>
		public addressed_value address_of
		{
			get
			{
				return _address_of;
			}
			set
			{
				_address_of=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			get_address copy = new get_address();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (address_of != null)
			{
				copy.address_of = (addressed_value)address_of.Clone();
				copy.address_of.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new get_address TypedClone()
		{
			return Clone() as get_address;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (address_of != null)
				address_of.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			address_of?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return address_of;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						address_of = (addressed_value)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class case_variant : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public case_variant()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public case_variant(expression_list _conditions,statement _exec_if_true)
		{
			this._conditions=_conditions;
			this._exec_if_true=_exec_if_true;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public case_variant(expression_list _conditions,statement _exec_if_true,SourceContext sc)
		{
			this._conditions=_conditions;
			this._exec_if_true=_exec_if_true;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression_list _conditions;
		protected statement _exec_if_true;

		///<summary>
		///
		///</summary>
		public expression_list conditions
		{
			get
			{
				return _conditions;
			}
			set
			{
				_conditions=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement exec_if_true
		{
			get
			{
				return _exec_if_true;
			}
			set
			{
				_exec_if_true=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			case_variant copy = new case_variant();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (conditions != null)
			{
				copy.conditions = (expression_list)conditions.Clone();
				copy.conditions.Parent = copy;
			}
			if (exec_if_true != null)
			{
				copy.exec_if_true = (statement)exec_if_true.Clone();
				copy.exec_if_true.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new case_variant TypedClone()
		{
			return Clone() as case_variant;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (conditions != null)
				conditions.Parent = this;
			if (exec_if_true != null)
				exec_if_true.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			conditions?.FillParentsInAllChilds();
			exec_if_true?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return conditions;
					case 1:
						return exec_if_true;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						conditions = (expression_list)value;
						break;
					case 1:
						exec_if_true = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class case_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public case_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public case_node(expression _param,case_variants _conditions,statement _else_statement)
		{
			this._param=_param;
			this._conditions=_conditions;
			this._else_statement=_else_statement;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public case_node(expression _param,case_variants _conditions,statement _else_statement,SourceContext sc)
		{
			this._param=_param;
			this._conditions=_conditions;
			this._else_statement=_else_statement;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _param;
		protected case_variants _conditions;
		protected statement _else_statement;

		///<summary>
		///
		///</summary>
		public expression param
		{
			get
			{
				return _param;
			}
			set
			{
				_param=value;
			}
		}

		///<summary>
		///
		///</summary>
		public case_variants conditions
		{
			get
			{
				return _conditions;
			}
			set
			{
				_conditions=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement else_statement
		{
			get
			{
				return _else_statement;
			}
			set
			{
				_else_statement=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			case_node copy = new case_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (param != null)
			{
				copy.param = (expression)param.Clone();
				copy.param.Parent = copy;
			}
			if (conditions != null)
			{
				copy.conditions = (case_variants)conditions.Clone();
				copy.conditions.Parent = copy;
			}
			if (else_statement != null)
			{
				copy.else_statement = (statement)else_statement.Clone();
				copy.else_statement.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new case_node TypedClone()
		{
			return Clone() as case_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (param != null)
				param.Parent = this;
			if (conditions != null)
				conditions.Parent = this;
			if (else_statement != null)
				else_statement.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			param?.FillParentsInAllChilds();
			conditions?.FillParentsInAllChilds();
			else_statement?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return param;
					case 1:
						return conditions;
					case 2:
						return else_statement;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						param = (expression)value;
						break;
					case 1:
						conditions = (case_variants)value;
						break;
					case 2:
						else_statement = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class method_name : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public method_name()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public method_name(List<ident> _ln,ident _class_name,ident _meth_name,ident _explicit_interface_name)
		{
			this._ln=_ln;
			this._class_name=_class_name;
			this._meth_name=_meth_name;
			this._explicit_interface_name=_explicit_interface_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public method_name(List<ident> _ln,ident _class_name,ident _meth_name,ident _explicit_interface_name,SourceContext sc)
		{
			this._ln=_ln;
			this._class_name=_class_name;
			this._meth_name=_meth_name;
			this._explicit_interface_name=_explicit_interface_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public method_name(ident elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<ident> _ln;
		protected ident _class_name;
		protected ident _meth_name;
		protected ident _explicit_interface_name;

		///<summary>
		///
		///</summary>
		public List<ident> ln
		{
			get
			{
				return _ln;
			}
			set
			{
				_ln=value;
			}
		}

		///<summary>
		///
		///</summary>
		public ident class_name
		{
			get
			{
				return _class_name;
			}
			set
			{
				_class_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public ident meth_name
		{
			get
			{
				return _meth_name;
			}
			set
			{
				_meth_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public ident explicit_interface_name
		{
			get
			{
				return _explicit_interface_name;
			}
			set
			{
				_explicit_interface_name=value;
			}
		}


		public method_name Add(ident elem, SourceContext sc = null)
		{
			ln.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(ident el)
		{
			ln.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<ident> els)
		{
			ln.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params ident[] els)
		{
			ln.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(ident el)
		{
			var ind = ln.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(ident el, ident newel)
		{
			ln.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(ident el, IEnumerable<ident> newels)
		{
			ln.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(ident el, ident newel)
		{
			ln.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(ident el, IEnumerable<ident> newels)
		{
			ln.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(ident el)
		{
			return ln.Remove(el);
		}
		
		public void ReplaceInList(ident el, ident newel)
		{
			ln[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(ident el, IEnumerable<ident> newels)
		{
			var ind = FindIndexInList(el);
			ln.RemoveAt(ind);
			ln.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<ident> match)
		{
			return ln.RemoveAll(match);
		}
		
		public ident Last()
		{
			return ln[ln.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			method_name copy = new method_name();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (ln != null)
			{
				foreach (ident elem in ln)
				{
					if (elem != null)
					{
						copy.Add((ident)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			if (class_name != null)
			{
				copy.class_name = (ident)class_name.Clone();
				copy.class_name.Parent = copy;
			}
			if (meth_name != null)
			{
				copy.meth_name = (ident)meth_name.Clone();
				copy.meth_name.Parent = copy;
			}
			if (explicit_interface_name != null)
			{
				copy.explicit_interface_name = (ident)explicit_interface_name.Clone();
				copy.explicit_interface_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new method_name TypedClone()
		{
			return Clone() as method_name;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (ln != null)
			{
				foreach (var child in ln)
					if (child != null)
						child.Parent = this;
			}
			if (class_name != null)
				class_name.Parent = this;
			if (meth_name != null)
				meth_name.Parent = this;
			if (explicit_interface_name != null)
				explicit_interface_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (ln != null)
			{
				foreach (var child in ln)
					child?.FillParentsInAllChilds();
			}
			class_name?.FillParentsInAllChilds();
			meth_name?.FillParentsInAllChilds();
			explicit_interface_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3 + (ln == null ? 0 : ln.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return class_name;
					case 1:
						return meth_name;
					case 2:
						return explicit_interface_name;
				}
				Int32 index_counter=ind - 3;
				if(ln != null)
				{
					if(index_counter < ln.Count)
					{
						return ln[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						class_name = (ident)value;
						break;
					case 1:
						meth_name = (ident)value;
						break;
					case 2:
						explicit_interface_name = (ident)value;
						break;
				}
				Int32 index_counter=ind - 3;
				if(ln != null)
				{
					if(index_counter < ln.Count)
					{
						ln[index_counter]= (ident)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class dot_node : addressed_value_funcname
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public dot_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public dot_node(addressed_value _left,addressed_value _right)
		{
			this._left=_left;
			this._right=_right;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public dot_node(addressed_value _left,addressed_value _right,SourceContext sc)
		{
			this._left=_left;
			this._right=_right;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _left;
		protected addressed_value _right;

		///<summary>
		///
		///</summary>
		public addressed_value left
		{
			get
			{
				return _left;
			}
			set
			{
				_left=value;
			}
		}

		///<summary>
		///
		///</summary>
		public addressed_value right
		{
			get
			{
				return _right;
			}
			set
			{
				_right=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			dot_node copy = new dot_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (left != null)
			{
				copy.left = (addressed_value)left.Clone();
				copy.left.Parent = copy;
			}
			if (right != null)
			{
				copy.right = (addressed_value)right.Clone();
				copy.right.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new dot_node TypedClone()
		{
			return Clone() as dot_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (left != null)
				left.Parent = this;
			if (right != null)
				right.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			left?.FillParentsInAllChilds();
			right?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return left;
					case 1:
						return right;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						left = (addressed_value)value;
						break;
					case 1:
						right = (addressed_value)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class empty_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public empty_statement()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			empty_statement copy = new empty_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new empty_statement TypedClone()
		{
			return Clone() as empty_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class goto_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public goto_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public goto_statement(ident _label)
		{
			this._label=_label;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public goto_statement(ident _label,SourceContext sc)
		{
			this._label=_label;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _label;

		///<summary>
		///
		///</summary>
		public ident label
		{
			get
			{
				return _label;
			}
			set
			{
				_label=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			goto_statement copy = new goto_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (label != null)
			{
				copy.label = (ident)label.Clone();
				copy.label.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new goto_statement TypedClone()
		{
			return Clone() as goto_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (label != null)
				label.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			label?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return label;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						label = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class labeled_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public labeled_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public labeled_statement(ident _label_name,statement _to_statement)
		{
			this._label_name=_label_name;
			this._to_statement=_to_statement;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public labeled_statement(ident _label_name,statement _to_statement,SourceContext sc)
		{
			this._label_name=_label_name;
			this._to_statement=_to_statement;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _label_name;
		protected statement _to_statement;

		///<summary>
		///
		///</summary>
		public ident label_name
		{
			get
			{
				return _label_name;
			}
			set
			{
				_label_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement to_statement
		{
			get
			{
				return _to_statement;
			}
			set
			{
				_to_statement=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			labeled_statement copy = new labeled_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (label_name != null)
			{
				copy.label_name = (ident)label_name.Clone();
				copy.label_name.Parent = copy;
			}
			if (to_statement != null)
			{
				copy.to_statement = (statement)to_statement.Clone();
				copy.to_statement.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new labeled_statement TypedClone()
		{
			return Clone() as labeled_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (label_name != null)
				label_name.Parent = this;
			if (to_statement != null)
				to_statement.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			label_name?.FillParentsInAllChilds();
			to_statement?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return label_name;
					case 1:
						return to_statement;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						label_name = (ident)value;
						break;
					case 1:
						to_statement = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Представление оператора with в синтаксическом дереве.
	///</summary>
	[Serializable]
	public partial class with_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public with_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public with_statement(statement _what_do,expression_list _do_with)
		{
			this._what_do=_what_do;
			this._do_with=_do_with;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public with_statement(statement _what_do,expression_list _do_with,SourceContext sc)
		{
			this._what_do=_what_do;
			this._do_with=_do_with;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement _what_do;
		protected expression_list _do_with;

		///<summary>
		///Что делать.
		///</summary>
		public statement what_do
		{
			get
			{
				return _what_do;
			}
			set
			{
				_what_do=value;
			}
		}

		///<summary>
		///Список объектов, с которыми производить действия.
		///</summary>
		public expression_list do_with
		{
			get
			{
				return _do_with;
			}
			set
			{
				_do_with=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			with_statement copy = new with_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (what_do != null)
			{
				copy.what_do = (statement)what_do.Clone();
				copy.what_do.Parent = copy;
			}
			if (do_with != null)
			{
				copy.do_with = (expression_list)do_with.Clone();
				copy.do_with.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new with_statement TypedClone()
		{
			return Clone() as with_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (what_do != null)
				what_do.Parent = this;
			if (do_with != null)
				do_with.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			what_do?.FillParentsInAllChilds();
			do_with?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return what_do;
					case 1:
						return do_with;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						what_do = (statement)value;
						break;
					case 1:
						do_with = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class method_call : dereference
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public method_call()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public method_call(expression_list _parameters)
		{
			this._parameters=_parameters;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public method_call(expression_list _parameters,SourceContext sc)
		{
			this._parameters=_parameters;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public method_call(addressed_value _dereferencing_value,expression_list _parameters)
		{
			this._dereferencing_value=_dereferencing_value;
			this._parameters=_parameters;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public method_call(addressed_value _dereferencing_value,expression_list _parameters,SourceContext sc)
		{
			this._dereferencing_value=_dereferencing_value;
			this._parameters=_parameters;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression_list _parameters;

		///<summary>
		///
		///</summary>
		public expression_list parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			method_call copy = new method_call();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (dereferencing_value != null)
			{
				copy.dereferencing_value = (addressed_value)dereferencing_value.Clone();
				copy.dereferencing_value.Parent = copy;
			}
			if (parameters != null)
			{
				copy.parameters = (expression_list)parameters.Clone();
				copy.parameters.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new method_call TypedClone()
		{
			return Clone() as method_call;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (dereferencing_value != null)
				dereferencing_value.Parent = this;
			if (parameters != null)
				parameters.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			dereferencing_value?.FillParentsInAllChilds();
			parameters?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return dereferencing_value;
					case 1:
						return parameters;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						dereferencing_value = (addressed_value)value;
						break;
					case 1:
						parameters = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Выражение-константа множество
	///</summary>
	[Serializable]
	public partial class pascal_set_constant : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public pascal_set_constant()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public pascal_set_constant(expression_list _values)
		{
			this._values=_values;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public pascal_set_constant(expression_list _values,SourceContext sc)
		{
			this._values=_values;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression_list _values;

		///<summary>
		///
		///</summary>
		public expression_list values
		{
			get
			{
				return _values;
			}
			set
			{
				_values=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			pascal_set_constant copy = new pascal_set_constant();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (values != null)
			{
				copy.values = (expression_list)values.Clone();
				copy.values.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new pascal_set_constant TypedClone()
		{
			return Clone() as pascal_set_constant;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (values != null)
				values.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			values?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return values;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						values = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class array_const : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public array_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_const(expression_list _elements)
		{
			this._elements=_elements;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_const(expression_list _elements,SourceContext sc)
		{
			this._elements=_elements;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression_list _elements;

		///<summary>
		///
		///</summary>
		public expression_list elements
		{
			get
			{
				return _elements;
			}
			set
			{
				_elements=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			array_const copy = new array_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (elements != null)
			{
				copy.elements = (expression_list)elements.Clone();
				copy.elements.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new array_const TypedClone()
		{
			return Clone() as array_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (elements != null)
				elements.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			elements?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return elements;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						elements = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class write_accessor_name : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public write_accessor_name()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public write_accessor_name(ident _accessor_name)
		{
			this._accessor_name=_accessor_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public write_accessor_name(ident _accessor_name,SourceContext sc)
		{
			this._accessor_name=_accessor_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _accessor_name;

		///<summary>
		///
		///</summary>
		public ident accessor_name
		{
			get
			{
				return _accessor_name;
			}
			set
			{
				_accessor_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			write_accessor_name copy = new write_accessor_name();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (accessor_name != null)
			{
				copy.accessor_name = (ident)accessor_name.Clone();
				copy.accessor_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new write_accessor_name TypedClone()
		{
			return Clone() as write_accessor_name;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (accessor_name != null)
				accessor_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			accessor_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return accessor_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						accessor_name = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class read_accessor_name : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public read_accessor_name()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public read_accessor_name(ident _accessor_name)
		{
			this._accessor_name=_accessor_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public read_accessor_name(ident _accessor_name,SourceContext sc)
		{
			this._accessor_name=_accessor_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _accessor_name;

		///<summary>
		///
		///</summary>
		public ident accessor_name
		{
			get
			{
				return _accessor_name;
			}
			set
			{
				_accessor_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			read_accessor_name copy = new read_accessor_name();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (accessor_name != null)
			{
				copy.accessor_name = (ident)accessor_name.Clone();
				copy.accessor_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new read_accessor_name TypedClone()
		{
			return Clone() as read_accessor_name;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (accessor_name != null)
				accessor_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			accessor_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return accessor_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						accessor_name = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class property_accessors : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public property_accessors()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_accessors(read_accessor_name _read_accessor,write_accessor_name _write_accessor)
		{
			this._read_accessor=_read_accessor;
			this._write_accessor=_write_accessor;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_accessors(read_accessor_name _read_accessor,write_accessor_name _write_accessor,SourceContext sc)
		{
			this._read_accessor=_read_accessor;
			this._write_accessor=_write_accessor;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected read_accessor_name _read_accessor;
		protected write_accessor_name _write_accessor;

		///<summary>
		///
		///</summary>
		public read_accessor_name read_accessor
		{
			get
			{
				return _read_accessor;
			}
			set
			{
				_read_accessor=value;
			}
		}

		///<summary>
		///
		///</summary>
		public write_accessor_name write_accessor
		{
			get
			{
				return _write_accessor;
			}
			set
			{
				_write_accessor=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			property_accessors copy = new property_accessors();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (read_accessor != null)
			{
				copy.read_accessor = (read_accessor_name)read_accessor.Clone();
				copy.read_accessor.Parent = copy;
			}
			if (write_accessor != null)
			{
				copy.write_accessor = (write_accessor_name)write_accessor.Clone();
				copy.write_accessor.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new property_accessors TypedClone()
		{
			return Clone() as property_accessors;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (read_accessor != null)
				read_accessor.Parent = this;
			if (write_accessor != null)
				write_accessor.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			read_accessor?.FillParentsInAllChilds();
			write_accessor?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return read_accessor;
					case 1:
						return write_accessor;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						read_accessor = (read_accessor_name)value;
						break;
					case 1:
						write_accessor = (write_accessor_name)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///property property_name[parameter_list]:property_type index index_expression accessors;array_default;
	///</summary>
	[Serializable]
	public partial class simple_property : declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public simple_property()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public simple_property(ident _property_name,type_definition _property_type,expression _index_expression,property_accessors _accessors,property_array_default _array_default,property_parameter_list _parameter_list,definition_attribute _attr)
		{
			this._property_name=_property_name;
			this._property_type=_property_type;
			this._index_expression=_index_expression;
			this._accessors=_accessors;
			this._array_default=_array_default;
			this._parameter_list=_parameter_list;
			this._attr=_attr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public simple_property(ident _property_name,type_definition _property_type,expression _index_expression,property_accessors _accessors,property_array_default _array_default,property_parameter_list _parameter_list,definition_attribute _attr,SourceContext sc)
		{
			this._property_name=_property_name;
			this._property_type=_property_type;
			this._index_expression=_index_expression;
			this._accessors=_accessors;
			this._array_default=_array_default;
			this._parameter_list=_parameter_list;
			this._attr=_attr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _property_name;
		protected type_definition _property_type;
		protected expression _index_expression;
		protected property_accessors _accessors;
		protected property_array_default _array_default;
		protected property_parameter_list _parameter_list;
		protected definition_attribute _attr;

		///<summary>
		///
		///</summary>
		public ident property_name
		{
			get
			{
				return _property_name;
			}
			set
			{
				_property_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition property_type
		{
			get
			{
				return _property_type;
			}
			set
			{
				_property_type=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression index_expression
		{
			get
			{
				return _index_expression;
			}
			set
			{
				_index_expression=value;
			}
		}

		///<summary>
		///
		///</summary>
		public property_accessors accessors
		{
			get
			{
				return _accessors;
			}
			set
			{
				_accessors=value;
			}
		}

		///<summary>
		///
		///</summary>
		public property_array_default array_default
		{
			get
			{
				return _array_default;
			}
			set
			{
				_array_default=value;
			}
		}

		///<summary>
		///
		///</summary>
		public property_parameter_list parameter_list
		{
			get
			{
				return _parameter_list;
			}
			set
			{
				_parameter_list=value;
			}
		}

		///<summary>
		///
		///</summary>
		public definition_attribute attr
		{
			get
			{
				return _attr;
			}
			set
			{
				_attr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			simple_property copy = new simple_property();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (property_name != null)
			{
				copy.property_name = (ident)property_name.Clone();
				copy.property_name.Parent = copy;
			}
			if (property_type != null)
			{
				copy.property_type = (type_definition)property_type.Clone();
				copy.property_type.Parent = copy;
			}
			if (index_expression != null)
			{
				copy.index_expression = (expression)index_expression.Clone();
				copy.index_expression.Parent = copy;
			}
			if (accessors != null)
			{
				copy.accessors = (property_accessors)accessors.Clone();
				copy.accessors.Parent = copy;
			}
			if (array_default != null)
			{
				copy.array_default = (property_array_default)array_default.Clone();
				copy.array_default.Parent = copy;
			}
			if (parameter_list != null)
			{
				copy.parameter_list = (property_parameter_list)parameter_list.Clone();
				copy.parameter_list.Parent = copy;
			}
			copy.attr = attr;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new simple_property TypedClone()
		{
			return Clone() as simple_property;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (property_name != null)
				property_name.Parent = this;
			if (property_type != null)
				property_type.Parent = this;
			if (index_expression != null)
				index_expression.Parent = this;
			if (accessors != null)
				accessors.Parent = this;
			if (array_default != null)
				array_default.Parent = this;
			if (parameter_list != null)
				parameter_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			property_name?.FillParentsInAllChilds();
			property_type?.FillParentsInAllChilds();
			index_expression?.FillParentsInAllChilds();
			accessors?.FillParentsInAllChilds();
			array_default?.FillParentsInAllChilds();
			parameter_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return property_name;
					case 1:
						return property_type;
					case 2:
						return index_expression;
					case 3:
						return accessors;
					case 4:
						return array_default;
					case 5:
						return parameter_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						property_name = (ident)value;
						break;
					case 1:
						property_type = (type_definition)value;
						break;
					case 2:
						index_expression = (expression)value;
						break;
					case 3:
						accessors = (property_accessors)value;
						break;
					case 4:
						array_default = (property_array_default)value;
						break;
					case 5:
						parameter_list = (property_parameter_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class index_property : simple_property
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public index_property()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public index_property(formal_parameters _property_parametres,default_indexer_property_node _is_default)
		{
			this._property_parametres=_property_parametres;
			this._is_default=_is_default;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public index_property(formal_parameters _property_parametres,default_indexer_property_node _is_default,SourceContext sc)
		{
			this._property_parametres=_property_parametres;
			this._is_default=_is_default;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public index_property(ident _property_name,type_definition _property_type,expression _index_expression,property_accessors _accessors,property_array_default _array_default,property_parameter_list _parameter_list,definition_attribute _attr,formal_parameters _property_parametres,default_indexer_property_node _is_default)
		{
			this._property_name=_property_name;
			this._property_type=_property_type;
			this._index_expression=_index_expression;
			this._accessors=_accessors;
			this._array_default=_array_default;
			this._parameter_list=_parameter_list;
			this._attr=_attr;
			this._property_parametres=_property_parametres;
			this._is_default=_is_default;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public index_property(ident _property_name,type_definition _property_type,expression _index_expression,property_accessors _accessors,property_array_default _array_default,property_parameter_list _parameter_list,definition_attribute _attr,formal_parameters _property_parametres,default_indexer_property_node _is_default,SourceContext sc)
		{
			this._property_name=_property_name;
			this._property_type=_property_type;
			this._index_expression=_index_expression;
			this._accessors=_accessors;
			this._array_default=_array_default;
			this._parameter_list=_parameter_list;
			this._attr=_attr;
			this._property_parametres=_property_parametres;
			this._is_default=_is_default;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected formal_parameters _property_parametres;
		protected default_indexer_property_node _is_default;

		///<summary>
		///
		///</summary>
		public formal_parameters property_parametres
		{
			get
			{
				return _property_parametres;
			}
			set
			{
				_property_parametres=value;
			}
		}

		///<summary>
		///
		///</summary>
		public default_indexer_property_node is_default
		{
			get
			{
				return _is_default;
			}
			set
			{
				_is_default=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			index_property copy = new index_property();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (property_name != null)
			{
				copy.property_name = (ident)property_name.Clone();
				copy.property_name.Parent = copy;
			}
			if (property_type != null)
			{
				copy.property_type = (type_definition)property_type.Clone();
				copy.property_type.Parent = copy;
			}
			if (index_expression != null)
			{
				copy.index_expression = (expression)index_expression.Clone();
				copy.index_expression.Parent = copy;
			}
			if (accessors != null)
			{
				copy.accessors = (property_accessors)accessors.Clone();
				copy.accessors.Parent = copy;
			}
			if (array_default != null)
			{
				copy.array_default = (property_array_default)array_default.Clone();
				copy.array_default.Parent = copy;
			}
			if (parameter_list != null)
			{
				copy.parameter_list = (property_parameter_list)parameter_list.Clone();
				copy.parameter_list.Parent = copy;
			}
			copy.attr = attr;
			if (property_parametres != null)
			{
				copy.property_parametres = (formal_parameters)property_parametres.Clone();
				copy.property_parametres.Parent = copy;
			}
			if (is_default != null)
			{
				copy.is_default = (default_indexer_property_node)is_default.Clone();
				copy.is_default.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new index_property TypedClone()
		{
			return Clone() as index_property;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (property_name != null)
				property_name.Parent = this;
			if (property_type != null)
				property_type.Parent = this;
			if (index_expression != null)
				index_expression.Parent = this;
			if (accessors != null)
				accessors.Parent = this;
			if (array_default != null)
				array_default.Parent = this;
			if (parameter_list != null)
				parameter_list.Parent = this;
			if (property_parametres != null)
				property_parametres.Parent = this;
			if (is_default != null)
				is_default.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			property_name?.FillParentsInAllChilds();
			property_type?.FillParentsInAllChilds();
			index_expression?.FillParentsInAllChilds();
			accessors?.FillParentsInAllChilds();
			array_default?.FillParentsInAllChilds();
			parameter_list?.FillParentsInAllChilds();
			property_parametres?.FillParentsInAllChilds();
			is_default?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 8;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 8;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return property_name;
					case 1:
						return property_type;
					case 2:
						return index_expression;
					case 3:
						return accessors;
					case 4:
						return array_default;
					case 5:
						return parameter_list;
					case 6:
						return property_parametres;
					case 7:
						return is_default;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						property_name = (ident)value;
						break;
					case 1:
						property_type = (type_definition)value;
						break;
					case 2:
						index_expression = (expression)value;
						break;
					case 3:
						accessors = (property_accessors)value;
						break;
					case 4:
						array_default = (property_array_default)value;
						break;
					case 5:
						parameter_list = (property_parameter_list)value;
						break;
					case 6:
						property_parametres = (formal_parameters)value;
						break;
					case 7:
						is_default = (default_indexer_property_node)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class class_members : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public class_members()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_members(List<declaration> _members,access_modifer_node _access_mod)
		{
			this._members=_members;
			this._access_mod=_access_mod;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_members(List<declaration> _members,access_modifer_node _access_mod,SourceContext sc)
		{
			this._members=_members;
			this._access_mod=_access_mod;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public class_members(declaration elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<declaration> _members=new List<declaration>();
		protected access_modifer_node _access_mod;

		///<summary>
		///
		///</summary>
		public List<declaration> members
		{
			get
			{
				return _members;
			}
			set
			{
				_members=value;
			}
		}

		///<summary>
		///
		///</summary>
		public access_modifer_node access_mod
		{
			get
			{
				return _access_mod;
			}
			set
			{
				_access_mod=value;
			}
		}


		public class_members Add(declaration elem, SourceContext sc = null)
		{
			members.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(declaration el)
		{
			members.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<declaration> els)
		{
			members.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params declaration[] els)
		{
			members.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(declaration el)
		{
			var ind = members.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(declaration el, declaration newel)
		{
			members.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(declaration el, IEnumerable<declaration> newels)
		{
			members.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(declaration el, declaration newel)
		{
			members.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(declaration el, IEnumerable<declaration> newels)
		{
			members.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(declaration el)
		{
			return members.Remove(el);
		}
		
		public void ReplaceInList(declaration el, declaration newel)
		{
			members[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(declaration el, IEnumerable<declaration> newels)
		{
			var ind = FindIndexInList(el);
			members.RemoveAt(ind);
			members.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<declaration> match)
		{
			return members.RemoveAll(match);
		}
		
		public declaration Last()
		{
			return members[members.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			class_members copy = new class_members();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (members != null)
			{
				foreach (declaration elem in members)
				{
					if (elem != null)
					{
						copy.Add((declaration)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			if (access_mod != null)
			{
				copy.access_mod = (access_modifer_node)access_mod.Clone();
				copy.access_mod.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new class_members TypedClone()
		{
			return Clone() as class_members;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (members != null)
			{
				foreach (var child in members)
					if (child != null)
						child.Parent = this;
			}
			if (access_mod != null)
				access_mod.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (members != null)
			{
				foreach (var child in members)
					child?.FillParentsInAllChilds();
			}
			access_mod?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1 + (members == null ? 0 : members.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return access_mod;
				}
				Int32 index_counter=ind - 1;
				if(members != null)
				{
					if(index_counter < members.Count)
					{
						return members[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						access_mod = (access_modifer_node)value;
						break;
				}
				Int32 index_counter=ind - 1;
				if(members != null)
				{
					if(index_counter < members.Count)
					{
						members[index_counter]= (declaration)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class access_modifer_node : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public access_modifer_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public access_modifer_node(access_modifer _access_level)
		{
			this._access_level=_access_level;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public access_modifer_node(access_modifer _access_level,SourceContext sc)
		{
			this._access_level=_access_level;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected access_modifer _access_level;

		///<summary>
		///
		///</summary>
		public access_modifer access_level
		{
			get
			{
				return _access_level;
			}
			set
			{
				_access_level=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			access_modifer_node copy = new access_modifer_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.access_level = access_level;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new access_modifer_node TypedClone()
		{
			return Clone() as access_modifer_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class class_body : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public class_body()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_body(List<class_members> _class_def_blocks)
		{
			this._class_def_blocks=_class_def_blocks;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_body(List<class_members> _class_def_blocks,SourceContext sc)
		{
			this._class_def_blocks=_class_def_blocks;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public class_body(class_members elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<class_members> _class_def_blocks=new List<class_members>();

		///<summary>
		///
		///</summary>
		public List<class_members> class_def_blocks
		{
			get
			{
				return _class_def_blocks;
			}
			set
			{
				_class_def_blocks=value;
			}
		}


		public class_body Add(class_members elem, SourceContext sc = null)
		{
			class_def_blocks.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(class_members el)
		{
			class_def_blocks.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<class_members> els)
		{
			class_def_blocks.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params class_members[] els)
		{
			class_def_blocks.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(class_members el)
		{
			var ind = class_def_blocks.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(class_members el, class_members newel)
		{
			class_def_blocks.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(class_members el, IEnumerable<class_members> newels)
		{
			class_def_blocks.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(class_members el, class_members newel)
		{
			class_def_blocks.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(class_members el, IEnumerable<class_members> newels)
		{
			class_def_blocks.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(class_members el)
		{
			return class_def_blocks.Remove(el);
		}
		
		public void ReplaceInList(class_members el, class_members newel)
		{
			class_def_blocks[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(class_members el, IEnumerable<class_members> newels)
		{
			var ind = FindIndexInList(el);
			class_def_blocks.RemoveAt(ind);
			class_def_blocks.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<class_members> match)
		{
			return class_def_blocks.RemoveAll(match);
		}
		
		public class_members Last()
		{
			return class_def_blocks[class_def_blocks.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			class_body copy = new class_body();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (class_def_blocks != null)
			{
				foreach (class_members elem in class_def_blocks)
				{
					if (elem != null)
					{
						copy.Add((class_members)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new class_body TypedClone()
		{
			return Clone() as class_body;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (class_def_blocks != null)
			{
				foreach (var child in class_def_blocks)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (class_def_blocks != null)
			{
				foreach (var child in class_def_blocks)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (class_def_blocks == null ? 0 : class_def_blocks.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(class_def_blocks != null)
				{
					if(index_counter < class_def_blocks.Count)
					{
						return class_def_blocks[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(class_def_blocks != null)
				{
					if(index_counter < class_def_blocks.Count)
					{
						class_def_blocks[index_counter]= (class_members)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class class_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public class_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_definition(named_type_reference_list _class_parents,class_body _body,class_keyword _keyword,ident_list _template_args,where_definition_list _where_section,class_attribute _attribute,bool _is_auto)
		{
			this._class_parents=_class_parents;
			this._body=_body;
			this._keyword=_keyword;
			this._template_args=_template_args;
			this._where_section=_where_section;
			this._attribute=_attribute;
			this._is_auto=_is_auto;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_definition(named_type_reference_list _class_parents,class_body _body,class_keyword _keyword,ident_list _template_args,where_definition_list _where_section,class_attribute _attribute,bool _is_auto,SourceContext sc)
		{
			this._class_parents=_class_parents;
			this._body=_body;
			this._keyword=_keyword;
			this._template_args=_template_args;
			this._where_section=_where_section;
			this._attribute=_attribute;
			this._is_auto=_is_auto;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_definition(type_definition_attr_list _attr_list,named_type_reference_list _class_parents,class_body _body,class_keyword _keyword,ident_list _template_args,where_definition_list _where_section,class_attribute _attribute,bool _is_auto)
		{
			this._attr_list=_attr_list;
			this._class_parents=_class_parents;
			this._body=_body;
			this._keyword=_keyword;
			this._template_args=_template_args;
			this._where_section=_where_section;
			this._attribute=_attribute;
			this._is_auto=_is_auto;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_definition(type_definition_attr_list _attr_list,named_type_reference_list _class_parents,class_body _body,class_keyword _keyword,ident_list _template_args,where_definition_list _where_section,class_attribute _attribute,bool _is_auto,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._class_parents=_class_parents;
			this._body=_body;
			this._keyword=_keyword;
			this._template_args=_template_args;
			this._where_section=_where_section;
			this._attribute=_attribute;
			this._is_auto=_is_auto;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected named_type_reference_list _class_parents;
		protected class_body _body;
		protected class_keyword _keyword;
		protected ident_list _template_args;
		protected where_definition_list _where_section;
		protected class_attribute _attribute;
		protected bool _is_auto;

		///<summary>
		///
		///</summary>
		public named_type_reference_list class_parents
		{
			get
			{
				return _class_parents;
			}
			set
			{
				_class_parents=value;
			}
		}

		///<summary>
		///
		///</summary>
		public class_body body
		{
			get
			{
				return _body;
			}
			set
			{
				_body=value;
			}
		}

		///<summary>
		///
		///</summary>
		public class_keyword keyword
		{
			get
			{
				return _keyword;
			}
			set
			{
				_keyword=value;
			}
		}

		///<summary>
		///
		///</summary>
		public ident_list template_args
		{
			get
			{
				return _template_args;
			}
			set
			{
				_template_args=value;
			}
		}

		///<summary>
		///
		///</summary>
		public where_definition_list where_section
		{
			get
			{
				return _where_section;
			}
			set
			{
				_where_section=value;
			}
		}

		///<summary>
		///
		///</summary>
		public class_attribute attribute
		{
			get
			{
				return _attribute;
			}
			set
			{
				_attribute=value;
			}
		}

		///<summary>
		///
		///</summary>
		public bool is_auto
		{
			get
			{
				return _is_auto;
			}
			set
			{
				_is_auto=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			class_definition copy = new class_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (class_parents != null)
			{
				copy.class_parents = (named_type_reference_list)class_parents.Clone();
				copy.class_parents.Parent = copy;
			}
			if (body != null)
			{
				copy.body = (class_body)body.Clone();
				copy.body.Parent = copy;
			}
			copy.keyword = keyword;
			if (template_args != null)
			{
				copy.template_args = (ident_list)template_args.Clone();
				copy.template_args.Parent = copy;
			}
			if (where_section != null)
			{
				copy.where_section = (where_definition_list)where_section.Clone();
				copy.where_section.Parent = copy;
			}
			copy.attribute = attribute;
			copy.is_auto = is_auto;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new class_definition TypedClone()
		{
			return Clone() as class_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (class_parents != null)
				class_parents.Parent = this;
			if (body != null)
				body.Parent = this;
			if (template_args != null)
				template_args.Parent = this;
			if (where_section != null)
				where_section.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			class_parents?.FillParentsInAllChilds();
			body?.FillParentsInAllChilds();
			template_args?.FillParentsInAllChilds();
			where_section?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 5;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 5;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return class_parents;
					case 2:
						return body;
					case 3:
						return template_args;
					case 4:
						return where_section;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						class_parents = (named_type_reference_list)value;
						break;
					case 2:
						body = (class_body)value;
						break;
					case 3:
						template_args = (ident_list)value;
						break;
					case 4:
						where_section = (where_definition_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class default_indexer_property_node : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public default_indexer_property_node()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			default_indexer_property_node copy = new default_indexer_property_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new default_indexer_property_node TypedClone()
		{
			return Clone() as default_indexer_property_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class known_type_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public known_type_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_definition(known_type _tp,ident _unit_name)
		{
			this._tp=_tp;
			this._unit_name=_unit_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_definition(known_type _tp,ident _unit_name,SourceContext sc)
		{
			this._tp=_tp;
			this._unit_name=_unit_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_definition(type_definition_attr_list _attr_list,known_type _tp,ident _unit_name)
		{
			this._attr_list=_attr_list;
			this._tp=_tp;
			this._unit_name=_unit_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_definition(type_definition_attr_list _attr_list,known_type _tp,ident _unit_name,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._tp=_tp;
			this._unit_name=_unit_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected known_type _tp;
		protected ident _unit_name;

		///<summary>
		///
		///</summary>
		public known_type tp
		{
			get
			{
				return _tp;
			}
			set
			{
				_tp=value;
			}
		}

		///<summary>
		///
		///</summary>
		public ident unit_name
		{
			get
			{
				return _unit_name;
			}
			set
			{
				_unit_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			known_type_definition copy = new known_type_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			copy.tp = tp;
			if (unit_name != null)
			{
				copy.unit_name = (ident)unit_name.Clone();
				copy.unit_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new known_type_definition TypedClone()
		{
			return Clone() as known_type_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (unit_name != null)
				unit_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			unit_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return unit_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						unit_name = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class set_type_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public set_type_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public set_type_definition(type_definition _of_type)
		{
			this._of_type=_of_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public set_type_definition(type_definition _of_type,SourceContext sc)
		{
			this._of_type=_of_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public set_type_definition(type_definition_attr_list _attr_list,type_definition _of_type)
		{
			this._attr_list=_attr_list;
			this._of_type=_of_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public set_type_definition(type_definition_attr_list _attr_list,type_definition _of_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._of_type=_of_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _of_type;

		///<summary>
		///
		///</summary>
		public type_definition of_type
		{
			get
			{
				return _of_type;
			}
			set
			{
				_of_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			set_type_definition copy = new set_type_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (of_type != null)
			{
				copy.of_type = (type_definition)of_type.Clone();
				copy.of_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new set_type_definition TypedClone()
		{
			return Clone() as set_type_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (of_type != null)
				of_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			of_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return of_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						of_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class record_const_definition : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public record_const_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_const_definition(ident _name,expression _val)
		{
			this._name=_name;
			this._val=_val;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_const_definition(ident _name,expression _val,SourceContext sc)
		{
			this._name=_name;
			this._val=_val;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _name;
		protected expression _val;

		///<summary>
		///
		///</summary>
		public ident name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression val
		{
			get
			{
				return _val;
			}
			set
			{
				_val=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			record_const_definition copy = new record_const_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (ident)name.Clone();
				copy.name.Parent = copy;
			}
			if (val != null)
			{
				copy.val = (expression)val.Clone();
				copy.val.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new record_const_definition TypedClone()
		{
			return Clone() as record_const_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (name != null)
				name.Parent = this;
			if (val != null)
				val.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
			val?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return name;
					case 1:
						return val;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						name = (ident)value;
						break;
					case 1:
						val = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class record_const : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public record_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_const(List<record_const_definition> _rec_consts)
		{
			this._rec_consts=_rec_consts;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_const(List<record_const_definition> _rec_consts,SourceContext sc)
		{
			this._rec_consts=_rec_consts;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public record_const(record_const_definition elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<record_const_definition> _rec_consts=new List<record_const_definition>();

		///<summary>
		///
		///</summary>
		public List<record_const_definition> rec_consts
		{
			get
			{
				return _rec_consts;
			}
			set
			{
				_rec_consts=value;
			}
		}


		public record_const Add(record_const_definition elem, SourceContext sc = null)
		{
			rec_consts.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(record_const_definition el)
		{
			rec_consts.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<record_const_definition> els)
		{
			rec_consts.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params record_const_definition[] els)
		{
			rec_consts.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(record_const_definition el)
		{
			var ind = rec_consts.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(record_const_definition el, record_const_definition newel)
		{
			rec_consts.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(record_const_definition el, IEnumerable<record_const_definition> newels)
		{
			rec_consts.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(record_const_definition el, record_const_definition newel)
		{
			rec_consts.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(record_const_definition el, IEnumerable<record_const_definition> newels)
		{
			rec_consts.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(record_const_definition el)
		{
			return rec_consts.Remove(el);
		}
		
		public void ReplaceInList(record_const_definition el, record_const_definition newel)
		{
			rec_consts[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(record_const_definition el, IEnumerable<record_const_definition> newels)
		{
			var ind = FindIndexInList(el);
			rec_consts.RemoveAt(ind);
			rec_consts.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<record_const_definition> match)
		{
			return rec_consts.RemoveAll(match);
		}
		
		public record_const_definition Last()
		{
			return rec_consts[rec_consts.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			record_const copy = new record_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (rec_consts != null)
			{
				foreach (record_const_definition elem in rec_consts)
				{
					if (elem != null)
					{
						copy.Add((record_const_definition)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new record_const TypedClone()
		{
			return Clone() as record_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (rec_consts != null)
			{
				foreach (var child in rec_consts)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (rec_consts != null)
			{
				foreach (var child in rec_consts)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (rec_consts == null ? 0 : rec_consts.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(rec_consts != null)
				{
					if(index_counter < rec_consts.Count)
					{
						return rec_consts[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(rec_consts != null)
				{
					if(index_counter < rec_consts.Count)
					{
						rec_consts[index_counter]= (record_const_definition)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class record_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public record_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_type(record_type_parts _parts,type_definition _base_type)
		{
			this._parts=_parts;
			this._base_type=_base_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_type(record_type_parts _parts,type_definition _base_type,SourceContext sc)
		{
			this._parts=_parts;
			this._base_type=_base_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_type(type_definition_attr_list _attr_list,record_type_parts _parts,type_definition _base_type)
		{
			this._attr_list=_attr_list;
			this._parts=_parts;
			this._base_type=_base_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_type(type_definition_attr_list _attr_list,record_type_parts _parts,type_definition _base_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._parts=_parts;
			this._base_type=_base_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected record_type_parts _parts;
		protected type_definition _base_type;

		///<summary>
		///
		///</summary>
		public record_type_parts parts
		{
			get
			{
				return _parts;
			}
			set
			{
				_parts=value;
			}
		}

		///<summary>
		///in oberon2
		///</summary>
		public type_definition base_type
		{
			get
			{
				return _base_type;
			}
			set
			{
				_base_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			record_type copy = new record_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (parts != null)
			{
				copy.parts = (record_type_parts)parts.Clone();
				copy.parts.Parent = copy;
			}
			if (base_type != null)
			{
				copy.base_type = (type_definition)base_type.Clone();
				copy.base_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new record_type TypedClone()
		{
			return Clone() as record_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (parts != null)
				parts.Parent = this;
			if (base_type != null)
				base_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			parts?.FillParentsInAllChilds();
			base_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return parts;
					case 2:
						return base_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						parts = (record_type_parts)value;
						break;
					case 2:
						base_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class enum_type_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public enum_type_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enum_type_definition(enumerator_list _enumerators)
		{
			this._enumerators=_enumerators;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enum_type_definition(enumerator_list _enumerators,SourceContext sc)
		{
			this._enumerators=_enumerators;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enum_type_definition(type_definition_attr_list _attr_list,enumerator_list _enumerators)
		{
			this._attr_list=_attr_list;
			this._enumerators=_enumerators;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enum_type_definition(type_definition_attr_list _attr_list,enumerator_list _enumerators,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._enumerators=_enumerators;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected enumerator_list _enumerators;

		///<summary>
		///
		///</summary>
		public enumerator_list enumerators
		{
			get
			{
				return _enumerators;
			}
			set
			{
				_enumerators=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			enum_type_definition copy = new enum_type_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (enumerators != null)
			{
				copy.enumerators = (enumerator_list)enumerators.Clone();
				copy.enumerators.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new enum_type_definition TypedClone()
		{
			return Clone() as enum_type_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (enumerators != null)
				enumerators.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			enumerators?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return enumerators;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						enumerators = (enumerator_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Класс, представляющий символьную константу в синтаксическом дереве программы.
	///</summary>
	[Serializable]
	public partial class char_const : literal
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public char_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public char_const(char _cconst)
		{
			this._cconst=_cconst;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public char_const(char _cconst,SourceContext sc)
		{
			this._cconst=_cconst;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected char _cconst;

		///<summary>
		///
		///</summary>
		public char cconst
		{
			get
			{
				return _cconst;
			}
			set
			{
				_cconst=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			char_const copy = new char_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.cconst = cconst;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new char_const TypedClone()
		{
			return Clone() as char_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Выкидывание исключения.
	///</summary>
	[Serializable]
	public partial class raise_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public raise_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public raise_statement(expression _excep)
		{
			this._excep=_excep;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public raise_statement(expression _excep,SourceContext sc)
		{
			this._excep=_excep;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _excep;

		///<summary>
		///Выкидываемое исключение.
		///</summary>
		public expression excep
		{
			get
			{
				return _excep;
			}
			set
			{
				_excep=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			raise_statement copy = new raise_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (excep != null)
			{
				copy.excep = (expression)excep.Clone();
				copy.excep.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new raise_statement TypedClone()
		{
			return Clone() as raise_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (excep != null)
				excep.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			excep?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return excep;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						excep = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Представление в синтаксичеком дереве символьной константы вида #100.
	///</summary>
	[Serializable]
	public partial class sharp_char_const : literal
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public sharp_char_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sharp_char_const(int _char_num)
		{
			this._char_num=_char_num;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sharp_char_const(int _char_num,SourceContext sc)
		{
			this._char_num=_char_num;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected int _char_num;

		///<summary>
		///
		///</summary>
		public int char_num
		{
			get
			{
				return _char_num;
			}
			set
			{
				_char_num=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			sharp_char_const copy = new sharp_char_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.char_num = char_num;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new sharp_char_const TypedClone()
		{
			return Clone() as sharp_char_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Представляет в синтаксическом дереве строку вида #123'abc'#124#125.
	///</summary>
	[Serializable]
	public partial class literal_const_line : literal
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public literal_const_line()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public literal_const_line(List<literal> _literals)
		{
			this._literals=_literals;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public literal_const_line(List<literal> _literals,SourceContext sc)
		{
			this._literals=_literals;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public literal_const_line(literal elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<literal> _literals=new List<literal>();

		///<summary>
		///
		///</summary>
		public List<literal> literals
		{
			get
			{
				return _literals;
			}
			set
			{
				_literals=value;
			}
		}


		public literal_const_line Add(literal elem, SourceContext sc = null)
		{
			literals.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(literal el)
		{
			literals.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<literal> els)
		{
			literals.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params literal[] els)
		{
			literals.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(literal el)
		{
			var ind = literals.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(literal el, literal newel)
		{
			literals.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(literal el, IEnumerable<literal> newels)
		{
			literals.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(literal el, literal newel)
		{
			literals.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(literal el, IEnumerable<literal> newels)
		{
			literals.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(literal el)
		{
			return literals.Remove(el);
		}
		
		public void ReplaceInList(literal el, literal newel)
		{
			literals[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(literal el, IEnumerable<literal> newels)
		{
			var ind = FindIndexInList(el);
			literals.RemoveAt(ind);
			literals.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<literal> match)
		{
			return literals.RemoveAll(match);
		}
		
		public literal Last()
		{
			return literals[literals.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			literal_const_line copy = new literal_const_line();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (literals != null)
			{
				foreach (literal elem in literals)
				{
					if (elem != null)
					{
						copy.Add((literal)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new literal_const_line TypedClone()
		{
			return Clone() as literal_const_line;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (literals != null)
			{
				foreach (var child in literals)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (literals != null)
			{
				foreach (var child in literals)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (literals == null ? 0 : literals.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(literals != null)
				{
					if(index_counter < literals.Count)
					{
						return literals[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(literals != null)
				{
					if(index_counter < literals.Count)
					{
						literals[index_counter]= (literal)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Представление для класса строки вида string[256].
	///</summary>
	[Serializable]
	public partial class string_num_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public string_num_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public string_num_definition(expression _num_of_symbols,ident _name)
		{
			this._num_of_symbols=_num_of_symbols;
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public string_num_definition(expression _num_of_symbols,ident _name,SourceContext sc)
		{
			this._num_of_symbols=_num_of_symbols;
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public string_num_definition(type_definition_attr_list _attr_list,expression _num_of_symbols,ident _name)
		{
			this._attr_list=_attr_list;
			this._num_of_symbols=_num_of_symbols;
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public string_num_definition(type_definition_attr_list _attr_list,expression _num_of_symbols,ident _name,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._num_of_symbols=_num_of_symbols;
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _num_of_symbols;
		protected ident _name;

		///<summary>
		///Число символов в строке вида string[256].
		///</summary>
		public expression num_of_symbols
		{
			get
			{
				return _num_of_symbols;
			}
			set
			{
				_num_of_symbols=value;
			}
		}

		///<summary>
		///
		///</summary>
		public ident name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			string_num_definition copy = new string_num_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (num_of_symbols != null)
			{
				copy.num_of_symbols = (expression)num_of_symbols.Clone();
				copy.num_of_symbols.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (ident)name.Clone();
				copy.name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new string_num_definition TypedClone()
		{
			return Clone() as string_num_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (num_of_symbols != null)
				num_of_symbols.Parent = this;
			if (name != null)
				name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			num_of_symbols?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return num_of_symbols;
					case 2:
						return name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						num_of_symbols = (expression)value;
						break;
					case 2:
						name = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class variant : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public variant()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant(ident_list _vars,type_definition _vars_type)
		{
			this._vars=_vars;
			this._vars_type=_vars_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant(ident_list _vars,type_definition _vars_type,SourceContext sc)
		{
			this._vars=_vars;
			this._vars_type=_vars_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _vars;
		protected type_definition _vars_type;

		///<summary>
		///
		///</summary>
		public ident_list vars
		{
			get
			{
				return _vars;
			}
			set
			{
				_vars=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition vars_type
		{
			get
			{
				return _vars_type;
			}
			set
			{
				_vars_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			variant copy = new variant();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (vars != null)
			{
				copy.vars = (ident_list)vars.Clone();
				copy.vars.Parent = copy;
			}
			if (vars_type != null)
			{
				copy.vars_type = (type_definition)vars_type.Clone();
				copy.vars_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new variant TypedClone()
		{
			return Clone() as variant;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (vars != null)
				vars.Parent = this;
			if (vars_type != null)
				vars_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			vars?.FillParentsInAllChilds();
			vars_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return vars;
					case 1:
						return vars_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						vars = (ident_list)value;
						break;
					case 1:
						vars_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class variant_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public variant_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_list(List<variant> _vars)
		{
			this._vars=_vars;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_list(List<variant> _vars,SourceContext sc)
		{
			this._vars=_vars;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public variant_list(variant elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<variant> _vars=new List<variant>();

		///<summary>
		///
		///</summary>
		public List<variant> vars
		{
			get
			{
				return _vars;
			}
			set
			{
				_vars=value;
			}
		}


		public variant_list Add(variant elem, SourceContext sc = null)
		{
			vars.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(variant el)
		{
			vars.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<variant> els)
		{
			vars.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params variant[] els)
		{
			vars.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(variant el)
		{
			var ind = vars.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(variant el, variant newel)
		{
			vars.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(variant el, IEnumerable<variant> newels)
		{
			vars.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(variant el, variant newel)
		{
			vars.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(variant el, IEnumerable<variant> newels)
		{
			vars.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(variant el)
		{
			return vars.Remove(el);
		}
		
		public void ReplaceInList(variant el, variant newel)
		{
			vars[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(variant el, IEnumerable<variant> newels)
		{
			var ind = FindIndexInList(el);
			vars.RemoveAt(ind);
			vars.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<variant> match)
		{
			return vars.RemoveAll(match);
		}
		
		public variant Last()
		{
			return vars[vars.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			variant_list copy = new variant_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (vars != null)
			{
				foreach (variant elem in vars)
				{
					if (elem != null)
					{
						copy.Add((variant)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new variant_list TypedClone()
		{
			return Clone() as variant_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (vars != null)
			{
				foreach (var child in vars)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (vars != null)
			{
				foreach (var child in vars)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (vars == null ? 0 : vars.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(vars != null)
				{
					if(index_counter < vars.Count)
					{
						return vars[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(vars != null)
				{
					if(index_counter < vars.Count)
					{
						vars[index_counter]= (variant)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class variant_type : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public variant_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_type(expression_list _case_exprs,record_type_parts _parts)
		{
			this._case_exprs=_case_exprs;
			this._parts=_parts;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_type(expression_list _case_exprs,record_type_parts _parts,SourceContext sc)
		{
			this._case_exprs=_case_exprs;
			this._parts=_parts;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression_list _case_exprs;
		protected record_type_parts _parts;

		///<summary>
		///
		///</summary>
		public expression_list case_exprs
		{
			get
			{
				return _case_exprs;
			}
			set
			{
				_case_exprs=value;
			}
		}

		///<summary>
		///
		///</summary>
		public record_type_parts parts
		{
			get
			{
				return _parts;
			}
			set
			{
				_parts=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			variant_type copy = new variant_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (case_exprs != null)
			{
				copy.case_exprs = (expression_list)case_exprs.Clone();
				copy.case_exprs.Parent = copy;
			}
			if (parts != null)
			{
				copy.parts = (record_type_parts)parts.Clone();
				copy.parts.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new variant_type TypedClone()
		{
			return Clone() as variant_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (case_exprs != null)
				case_exprs.Parent = this;
			if (parts != null)
				parts.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			case_exprs?.FillParentsInAllChilds();
			parts?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return case_exprs;
					case 1:
						return parts;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						case_exprs = (expression_list)value;
						break;
					case 1:
						parts = (record_type_parts)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class variant_types : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public variant_types()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_types(List<variant_type> _vars)
		{
			this._vars=_vars;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_types(List<variant_type> _vars,SourceContext sc)
		{
			this._vars=_vars;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public variant_types(variant_type elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<variant_type> _vars=new List<variant_type>();

		///<summary>
		///
		///</summary>
		public List<variant_type> vars
		{
			get
			{
				return _vars;
			}
			set
			{
				_vars=value;
			}
		}


		public variant_types Add(variant_type elem, SourceContext sc = null)
		{
			vars.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(variant_type el)
		{
			vars.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<variant_type> els)
		{
			vars.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params variant_type[] els)
		{
			vars.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(variant_type el)
		{
			var ind = vars.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(variant_type el, variant_type newel)
		{
			vars.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(variant_type el, IEnumerable<variant_type> newels)
		{
			vars.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(variant_type el, variant_type newel)
		{
			vars.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(variant_type el, IEnumerable<variant_type> newels)
		{
			vars.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(variant_type el)
		{
			return vars.Remove(el);
		}
		
		public void ReplaceInList(variant_type el, variant_type newel)
		{
			vars[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(variant_type el, IEnumerable<variant_type> newels)
		{
			var ind = FindIndexInList(el);
			vars.RemoveAt(ind);
			vars.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<variant_type> match)
		{
			return vars.RemoveAll(match);
		}
		
		public variant_type Last()
		{
			return vars[vars.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			variant_types copy = new variant_types();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (vars != null)
			{
				foreach (variant_type elem in vars)
				{
					if (elem != null)
					{
						copy.Add((variant_type)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new variant_types TypedClone()
		{
			return Clone() as variant_types;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (vars != null)
			{
				foreach (var child in vars)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (vars != null)
			{
				foreach (var child in vars)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (vars == null ? 0 : vars.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(vars != null)
				{
					if(index_counter < vars.Count)
					{
						return vars[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(vars != null)
				{
					if(index_counter < vars.Count)
					{
						vars[index_counter]= (variant_type)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class variant_record_type : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public variant_record_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_record_type(ident _var_name,type_definition _var_type,variant_types _vars)
		{
			this._var_name=_var_name;
			this._var_type=_var_type;
			this._vars=_vars;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public variant_record_type(ident _var_name,type_definition _var_type,variant_types _vars,SourceContext sc)
		{
			this._var_name=_var_name;
			this._var_type=_var_type;
			this._vars=_vars;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _var_name;
		protected type_definition _var_type;
		protected variant_types _vars;

		///<summary>
		///
		///</summary>
		public ident var_name
		{
			get
			{
				return _var_name;
			}
			set
			{
				_var_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition var_type
		{
			get
			{
				return _var_type;
			}
			set
			{
				_var_type=value;
			}
		}

		///<summary>
		///
		///</summary>
		public variant_types vars
		{
			get
			{
				return _vars;
			}
			set
			{
				_vars=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			variant_record_type copy = new variant_record_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (var_name != null)
			{
				copy.var_name = (ident)var_name.Clone();
				copy.var_name.Parent = copy;
			}
			if (var_type != null)
			{
				copy.var_type = (type_definition)var_type.Clone();
				copy.var_type.Parent = copy;
			}
			if (vars != null)
			{
				copy.vars = (variant_types)vars.Clone();
				copy.vars.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new variant_record_type TypedClone()
		{
			return Clone() as variant_record_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (var_name != null)
				var_name.Parent = this;
			if (var_type != null)
				var_type.Parent = this;
			if (vars != null)
				vars.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			var_name?.FillParentsInAllChilds();
			var_type?.FillParentsInAllChilds();
			vars?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return var_name;
					case 1:
						return var_type;
					case 2:
						return vars;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						var_name = (ident)value;
						break;
					case 1:
						var_type = (type_definition)value;
						break;
					case 2:
						vars = (variant_types)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class procedure_call : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public procedure_call()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_call(addressed_value _func_name)
		{
			this._func_name=_func_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public procedure_call(addressed_value _func_name,SourceContext sc)
		{
			this._func_name=_func_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _func_name;

		///<summary>
		///
		///</summary>
		public addressed_value func_name
		{
			get
			{
				return _func_name;
			}
			set
			{
				_func_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			procedure_call copy = new procedure_call();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (func_name != null)
			{
				copy.func_name = (addressed_value)func_name.Clone();
				copy.func_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new procedure_call TypedClone()
		{
			return Clone() as procedure_call;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (func_name != null)
				func_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			func_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return func_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						func_name = (addressed_value)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class class_predefinition : type_declaration
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public class_predefinition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_predefinition(ident _class_name)
		{
			this._class_name=_class_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_predefinition(ident _class_name,SourceContext sc)
		{
			this._class_name=_class_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_predefinition(ident _type_name,type_definition _type_def,ident _class_name)
		{
			this._type_name=_type_name;
			this._type_def=_type_def;
			this._class_name=_class_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public class_predefinition(ident _type_name,type_definition _type_def,ident _class_name,SourceContext sc)
		{
			this._type_name=_type_name;
			this._type_def=_type_def;
			this._class_name=_class_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _class_name;

		///<summary>
		///
		///</summary>
		public ident class_name
		{
			get
			{
				return _class_name;
			}
			set
			{
				_class_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			class_predefinition copy = new class_predefinition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (ident)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			if (type_def != null)
			{
				copy.type_def = (type_definition)type_def.Clone();
				copy.type_def.Parent = copy;
			}
			if (class_name != null)
			{
				copy.class_name = (ident)class_name.Clone();
				copy.class_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new class_predefinition TypedClone()
		{
			return Clone() as class_predefinition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
			if (type_def != null)
				type_def.Parent = this;
			if (class_name != null)
				class_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
			type_def?.FillParentsInAllChilds();
			class_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return type_name;
					case 1:
						return type_def;
					case 2:
						return class_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						type_name = (ident)value;
						break;
					case 1:
						type_def = (type_definition)value;
						break;
					case 2:
						class_name = (ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class nil_const : const_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public nil_const()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			nil_const copy = new nil_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new nil_const TypedClone()
		{
			return Clone() as nil_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class file_type_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public file_type_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type_definition(type_definition _elem_type)
		{
			this._elem_type=_elem_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type_definition(type_definition _elem_type,SourceContext sc)
		{
			this._elem_type=_elem_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type_definition(type_definition_attr_list _attr_list,type_definition _elem_type)
		{
			this._attr_list=_attr_list;
			this._elem_type=_elem_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type_definition(type_definition_attr_list _attr_list,type_definition _elem_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._elem_type=_elem_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _elem_type;

		///<summary>
		///
		///</summary>
		public type_definition elem_type
		{
			get
			{
				return _elem_type;
			}
			set
			{
				_elem_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			file_type_definition copy = new file_type_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (elem_type != null)
			{
				copy.elem_type = (type_definition)elem_type.Clone();
				copy.elem_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new file_type_definition TypedClone()
		{
			return Clone() as file_type_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (elem_type != null)
				elem_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			elem_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return elem_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						elem_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class constructor : procedure_header
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public constructor()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public constructor(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public constructor(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			constructor copy = new constructor();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (parameters != null)
			{
				copy.parameters = (formal_parameters)parameters.Clone();
				copy.parameters.Parent = copy;
			}
			if (proc_attributes != null)
			{
				copy.proc_attributes = (procedure_attributes_list)proc_attributes.Clone();
				copy.proc_attributes.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (method_name)name.Clone();
				copy.name.Parent = copy;
			}
			copy.of_object = of_object;
			copy.class_keyword = class_keyword;
			if (template_args != null)
			{
				copy.template_args = (ident_list)template_args.Clone();
				copy.template_args.Parent = copy;
			}
			if (where_defs != null)
			{
				copy.where_defs = (where_definition_list)where_defs.Clone();
				copy.where_defs.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new constructor TypedClone()
		{
			return Clone() as constructor;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (parameters != null)
				parameters.Parent = this;
			if (proc_attributes != null)
				proc_attributes.Parent = this;
			if (name != null)
				name.Parent = this;
			if (template_args != null)
				template_args.Parent = this;
			if (where_defs != null)
				where_defs.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			parameters?.FillParentsInAllChilds();
			proc_attributes?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
			template_args?.FillParentsInAllChilds();
			where_defs?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return parameters;
					case 2:
						return proc_attributes;
					case 3:
						return name;
					case 4:
						return template_args;
					case 5:
						return where_defs;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						parameters = (formal_parameters)value;
						break;
					case 2:
						proc_attributes = (procedure_attributes_list)value;
						break;
					case 3:
						name = (method_name)value;
						break;
					case 4:
						template_args = (ident_list)value;
						break;
					case 5:
						where_defs = (where_definition_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class destructor : procedure_header
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public destructor()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public destructor(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public destructor(type_definition_attr_list _attr_list,formal_parameters _parameters,procedure_attributes_list _proc_attributes,method_name _name,bool _of_object,bool _class_keyword,ident_list _template_args,where_definition_list _where_defs,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._parameters=_parameters;
			this._proc_attributes=_proc_attributes;
			this._name=_name;
			this._of_object=_of_object;
			this._class_keyword=_class_keyword;
			this._template_args=_template_args;
			this._where_defs=_where_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			destructor copy = new destructor();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (parameters != null)
			{
				copy.parameters = (formal_parameters)parameters.Clone();
				copy.parameters.Parent = copy;
			}
			if (proc_attributes != null)
			{
				copy.proc_attributes = (procedure_attributes_list)proc_attributes.Clone();
				copy.proc_attributes.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (method_name)name.Clone();
				copy.name.Parent = copy;
			}
			copy.of_object = of_object;
			copy.class_keyword = class_keyword;
			if (template_args != null)
			{
				copy.template_args = (ident_list)template_args.Clone();
				copy.template_args.Parent = copy;
			}
			if (where_defs != null)
			{
				copy.where_defs = (where_definition_list)where_defs.Clone();
				copy.where_defs.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new destructor TypedClone()
		{
			return Clone() as destructor;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (parameters != null)
				parameters.Parent = this;
			if (proc_attributes != null)
				proc_attributes.Parent = this;
			if (name != null)
				name.Parent = this;
			if (template_args != null)
				template_args.Parent = this;
			if (where_defs != null)
				where_defs.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			parameters?.FillParentsInAllChilds();
			proc_attributes?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
			template_args?.FillParentsInAllChilds();
			where_defs?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 6;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return parameters;
					case 2:
						return proc_attributes;
					case 3:
						return name;
					case 4:
						return template_args;
					case 5:
						return where_defs;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						parameters = (formal_parameters)value;
						break;
					case 2:
						proc_attributes = (procedure_attributes_list)value;
						break;
					case 3:
						name = (method_name)value;
						break;
					case 4:
						template_args = (ident_list)value;
						break;
					case 5:
						where_defs = (where_definition_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class inherited_method_call : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public inherited_method_call()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public inherited_method_call(ident _method_name,expression_list _exprs)
		{
			this._method_name=_method_name;
			this._exprs=_exprs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public inherited_method_call(ident _method_name,expression_list _exprs,SourceContext sc)
		{
			this._method_name=_method_name;
			this._exprs=_exprs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _method_name;
		protected expression_list _exprs;

		///<summary>
		///
		///</summary>
		public ident method_name
		{
			get
			{
				return _method_name;
			}
			set
			{
				_method_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression_list exprs
		{
			get
			{
				return _exprs;
			}
			set
			{
				_exprs=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			inherited_method_call copy = new inherited_method_call();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (method_name != null)
			{
				copy.method_name = (ident)method_name.Clone();
				copy.method_name.Parent = copy;
			}
			if (exprs != null)
			{
				copy.exprs = (expression_list)exprs.Clone();
				copy.exprs.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new inherited_method_call TypedClone()
		{
			return Clone() as inherited_method_call;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (method_name != null)
				method_name.Parent = this;
			if (exprs != null)
				exprs.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			method_name?.FillParentsInAllChilds();
			exprs?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return method_name;
					case 1:
						return exprs;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						method_name = (ident)value;
						break;
					case 1:
						exprs = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class typecast_node : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public typecast_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typecast_node(addressed_value _expr,type_definition _type_def,op_typecast _cast_op)
		{
			this._expr=_expr;
			this._type_def=_type_def;
			this._cast_op=_cast_op;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typecast_node(addressed_value _expr,type_definition _type_def,op_typecast _cast_op,SourceContext sc)
		{
			this._expr=_expr;
			this._type_def=_type_def;
			this._cast_op=_cast_op;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _expr;
		protected type_definition _type_def;
		protected op_typecast _cast_op;

		///<summary>
		///
		///</summary>
		public addressed_value expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition type_def
		{
			get
			{
				return _type_def;
			}
			set
			{
				_type_def=value;
			}
		}

		///<summary>
		///
		///</summary>
		public op_typecast cast_op
		{
			get
			{
				return _cast_op;
			}
			set
			{
				_cast_op=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			typecast_node copy = new typecast_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (addressed_value)expr.Clone();
				copy.expr.Parent = copy;
			}
			if (type_def != null)
			{
				copy.type_def = (type_definition)type_def.Clone();
				copy.type_def.Parent = copy;
			}
			copy.cast_op = cast_op;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new typecast_node TypedClone()
		{
			return Clone() as typecast_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr != null)
				expr.Parent = this;
			if (type_def != null)
				type_def.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
			type_def?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr;
					case 1:
						return type_def;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr = (addressed_value)value;
						break;
					case 1:
						type_def = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class interface_node : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public interface_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public interface_node(declarations _interface_definitions,uses_list _uses_modules,using_list _using_namespaces)
		{
			this._interface_definitions=_interface_definitions;
			this._uses_modules=_uses_modules;
			this._using_namespaces=_using_namespaces;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public interface_node(declarations _interface_definitions,uses_list _uses_modules,using_list _using_namespaces,SourceContext sc)
		{
			this._interface_definitions=_interface_definitions;
			this._uses_modules=_uses_modules;
			this._using_namespaces=_using_namespaces;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected declarations _interface_definitions;
		protected uses_list _uses_modules;
		protected using_list _using_namespaces;

		///<summary>
		///
		///</summary>
		public declarations interface_definitions
		{
			get
			{
				return _interface_definitions;
			}
			set
			{
				_interface_definitions=value;
			}
		}

		///<summary>
		///
		///</summary>
		public uses_list uses_modules
		{
			get
			{
				return _uses_modules;
			}
			set
			{
				_uses_modules=value;
			}
		}

		///<summary>
		///
		///</summary>
		public using_list using_namespaces
		{
			get
			{
				return _using_namespaces;
			}
			set
			{
				_using_namespaces=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			interface_node copy = new interface_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (interface_definitions != null)
			{
				copy.interface_definitions = (declarations)interface_definitions.Clone();
				copy.interface_definitions.Parent = copy;
			}
			if (uses_modules != null)
			{
				copy.uses_modules = (uses_list)uses_modules.Clone();
				copy.uses_modules.Parent = copy;
			}
			if (using_namespaces != null)
			{
				copy.using_namespaces = (using_list)using_namespaces.Clone();
				copy.using_namespaces.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new interface_node TypedClone()
		{
			return Clone() as interface_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (interface_definitions != null)
				interface_definitions.Parent = this;
			if (uses_modules != null)
				uses_modules.Parent = this;
			if (using_namespaces != null)
				using_namespaces.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			interface_definitions?.FillParentsInAllChilds();
			uses_modules?.FillParentsInAllChilds();
			using_namespaces?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return interface_definitions;
					case 1:
						return uses_modules;
					case 2:
						return using_namespaces;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						interface_definitions = (declarations)value;
						break;
					case 1:
						uses_modules = (uses_list)value;
						break;
					case 2:
						using_namespaces = (using_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class implementation_node : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public implementation_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public implementation_node(uses_list _uses_modules,declarations _implementation_definitions,using_list _using_namespaces)
		{
			this._uses_modules=_uses_modules;
			this._implementation_definitions=_implementation_definitions;
			this._using_namespaces=_using_namespaces;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public implementation_node(uses_list _uses_modules,declarations _implementation_definitions,using_list _using_namespaces,SourceContext sc)
		{
			this._uses_modules=_uses_modules;
			this._implementation_definitions=_implementation_definitions;
			this._using_namespaces=_using_namespaces;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected uses_list _uses_modules;
		protected declarations _implementation_definitions;
		protected using_list _using_namespaces;

		///<summary>
		///
		///</summary>
		public uses_list uses_modules
		{
			get
			{
				return _uses_modules;
			}
			set
			{
				_uses_modules=value;
			}
		}

		///<summary>
		///
		///</summary>
		public declarations implementation_definitions
		{
			get
			{
				return _implementation_definitions;
			}
			set
			{
				_implementation_definitions=value;
			}
		}

		///<summary>
		///
		///</summary>
		public using_list using_namespaces
		{
			get
			{
				return _using_namespaces;
			}
			set
			{
				_using_namespaces=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			implementation_node copy = new implementation_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (uses_modules != null)
			{
				copy.uses_modules = (uses_list)uses_modules.Clone();
				copy.uses_modules.Parent = copy;
			}
			if (implementation_definitions != null)
			{
				copy.implementation_definitions = (declarations)implementation_definitions.Clone();
				copy.implementation_definitions.Parent = copy;
			}
			if (using_namespaces != null)
			{
				copy.using_namespaces = (using_list)using_namespaces.Clone();
				copy.using_namespaces.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new implementation_node TypedClone()
		{
			return Clone() as implementation_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (uses_modules != null)
				uses_modules.Parent = this;
			if (implementation_definitions != null)
				implementation_definitions.Parent = this;
			if (using_namespaces != null)
				using_namespaces.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			uses_modules?.FillParentsInAllChilds();
			implementation_definitions?.FillParentsInAllChilds();
			using_namespaces?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return uses_modules;
					case 1:
						return implementation_definitions;
					case 2:
						return using_namespaces;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						uses_modules = (uses_list)value;
						break;
					case 1:
						implementation_definitions = (declarations)value;
						break;
					case 2:
						using_namespaces = (using_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class diap_expr : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public diap_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diap_expr(expression _left,expression _right)
		{
			this._left=_left;
			this._right=_right;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diap_expr(expression _left,expression _right,SourceContext sc)
		{
			this._left=_left;
			this._right=_right;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _left;
		protected expression _right;

		///<summary>
		///
		///</summary>
		public expression left
		{
			get
			{
				return _left;
			}
			set
			{
				_left=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression right
		{
			get
			{
				return _right;
			}
			set
			{
				_right=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			diap_expr copy = new diap_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (left != null)
			{
				copy.left = (expression)left.Clone();
				copy.left.Parent = copy;
			}
			if (right != null)
			{
				copy.right = (expression)right.Clone();
				copy.right.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new diap_expr TypedClone()
		{
			return Clone() as diap_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (left != null)
				left.Parent = this;
			if (right != null)
				right.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			left?.FillParentsInAllChilds();
			right?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return left;
					case 1:
						return right;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						left = (expression)value;
						break;
					case 1:
						right = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class block : proc_block
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public block()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public block(declarations _defs,statement_list _program_code)
		{
			this._defs=_defs;
			this._program_code=_program_code;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public block(declarations _defs,statement_list _program_code,SourceContext sc)
		{
			this._defs=_defs;
			this._program_code=_program_code;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected declarations _defs;
		protected statement_list _program_code;

		///<summary>
		///
		///</summary>
		public declarations defs
		{
			get
			{
				return _defs;
			}
			set
			{
				_defs=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement_list program_code
		{
			get
			{
				return _program_code;
			}
			set
			{
				_program_code=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			block copy = new block();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (defs != null)
			{
				copy.defs = (declarations)defs.Clone();
				copy.defs.Parent = copy;
			}
			if (program_code != null)
			{
				copy.program_code = (statement_list)program_code.Clone();
				copy.program_code.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new block TypedClone()
		{
			return Clone() as block;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (defs != null)
				defs.Parent = this;
			if (program_code != null)
				program_code.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			defs?.FillParentsInAllChilds();
			program_code?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return defs;
					case 1:
						return program_code;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						defs = (declarations)value;
						break;
					case 1:
						program_code = (statement_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class proc_block : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public proc_block()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			proc_block copy = new proc_block();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new proc_block TypedClone()
		{
			return Clone() as proc_block;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///array of type_name
	///</summary>
	[Serializable]
	public partial class array_of_named_type_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public array_of_named_type_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_of_named_type_definition(named_type_reference _type_name)
		{
			this._type_name=_type_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_of_named_type_definition(named_type_reference _type_name,SourceContext sc)
		{
			this._type_name=_type_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_of_named_type_definition(type_definition_attr_list _attr_list,named_type_reference _type_name)
		{
			this._attr_list=_attr_list;
			this._type_name=_type_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_of_named_type_definition(type_definition_attr_list _attr_list,named_type_reference _type_name,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._type_name=_type_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected named_type_reference _type_name;

		///<summary>
		///
		///</summary>
		public named_type_reference type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			array_of_named_type_definition copy = new array_of_named_type_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (named_type_reference)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new array_of_named_type_definition TypedClone()
		{
			return Clone() as array_of_named_type_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return type_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						type_name = (named_type_reference)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///array of const
	///</summary>
	[Serializable]
	public partial class array_of_const_type_definition : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public array_of_const_type_definition()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_of_const_type_definition(type_definition_attr_list _attr_list)
		{
			this._attr_list=_attr_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_of_const_type_definition(type_definition_attr_list _attr_list,SourceContext sc)
		{
			this._attr_list=_attr_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			array_of_const_type_definition copy = new array_of_const_type_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new array_of_const_type_definition TypedClone()
		{
			return Clone() as array_of_const_type_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///#12 либо 'abc'
	///</summary>
	[Serializable]
	public partial class literal : const_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public literal()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			literal copy = new literal();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new literal TypedClone()
		{
			return Clone() as literal;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class case_variants : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public case_variants()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public case_variants(List<case_variant> _variants)
		{
			this._variants=_variants;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public case_variants(List<case_variant> _variants,SourceContext sc)
		{
			this._variants=_variants;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public case_variants(case_variant elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<case_variant> _variants=new List<case_variant>();

		///<summary>
		///
		///</summary>
		public List<case_variant> variants
		{
			get
			{
				return _variants;
			}
			set
			{
				_variants=value;
			}
		}


		public case_variants Add(case_variant elem, SourceContext sc = null)
		{
			variants.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(case_variant el)
		{
			variants.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<case_variant> els)
		{
			variants.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params case_variant[] els)
		{
			variants.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(case_variant el)
		{
			var ind = variants.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(case_variant el, case_variant newel)
		{
			variants.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(case_variant el, IEnumerable<case_variant> newels)
		{
			variants.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(case_variant el, case_variant newel)
		{
			variants.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(case_variant el, IEnumerable<case_variant> newels)
		{
			variants.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(case_variant el)
		{
			return variants.Remove(el);
		}
		
		public void ReplaceInList(case_variant el, case_variant newel)
		{
			variants[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(case_variant el, IEnumerable<case_variant> newels)
		{
			var ind = FindIndexInList(el);
			variants.RemoveAt(ind);
			variants.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<case_variant> match)
		{
			return variants.RemoveAll(match);
		}
		
		public case_variant Last()
		{
			return variants[variants.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			case_variants copy = new case_variants();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (variants != null)
			{
				foreach (case_variant elem in variants)
				{
					if (elem != null)
					{
						copy.Add((case_variant)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new case_variants TypedClone()
		{
			return Clone() as case_variants;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (variants != null)
			{
				foreach (var child in variants)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (variants != null)
			{
				foreach (var child in variants)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (variants == null ? 0 : variants.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(variants != null)
				{
					if(index_counter < variants.Count)
					{
						return variants[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(variants != null)
				{
					if(index_counter < variants.Count)
					{
						variants[index_counter]= (case_variant)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class diapason_expr : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public diapason_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diapason_expr(expression _left,expression _right)
		{
			this._left=_left;
			this._right=_right;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public diapason_expr(expression _left,expression _right,SourceContext sc)
		{
			this._left=_left;
			this._right=_right;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _left;
		protected expression _right;

		///<summary>
		///
		///</summary>
		public expression left
		{
			get
			{
				return _left;
			}
			set
			{
				_left=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression right
		{
			get
			{
				return _right;
			}
			set
			{
				_right=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			diapason_expr copy = new diapason_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (left != null)
			{
				copy.left = (expression)left.Clone();
				copy.left.Parent = copy;
			}
			if (right != null)
			{
				copy.right = (expression)right.Clone();
				copy.right.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new diapason_expr TypedClone()
		{
			return Clone() as diapason_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (left != null)
				left.Parent = this;
			if (right != null)
				right.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			left?.FillParentsInAllChilds();
			right?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return left;
					case 1:
						return right;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						left = (expression)value;
						break;
					case 1:
						right = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class var_def_list_for_record : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public var_def_list_for_record()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public var_def_list_for_record(List<var_def_statement> _vars)
		{
			this._vars=_vars;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public var_def_list_for_record(List<var_def_statement> _vars,SourceContext sc)
		{
			this._vars=_vars;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public var_def_list_for_record(var_def_statement elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<var_def_statement> _vars=new List<var_def_statement>();

		///<summary>
		///
		///</summary>
		public List<var_def_statement> vars
		{
			get
			{
				return _vars;
			}
			set
			{
				_vars=value;
			}
		}


		public var_def_list_for_record Add(var_def_statement elem, SourceContext sc = null)
		{
			vars.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(var_def_statement el)
		{
			vars.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<var_def_statement> els)
		{
			vars.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params var_def_statement[] els)
		{
			vars.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(var_def_statement el)
		{
			var ind = vars.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(var_def_statement el, var_def_statement newel)
		{
			vars.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(var_def_statement el, IEnumerable<var_def_statement> newels)
		{
			vars.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(var_def_statement el, var_def_statement newel)
		{
			vars.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(var_def_statement el, IEnumerable<var_def_statement> newels)
		{
			vars.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(var_def_statement el)
		{
			return vars.Remove(el);
		}
		
		public void ReplaceInList(var_def_statement el, var_def_statement newel)
		{
			vars[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(var_def_statement el, IEnumerable<var_def_statement> newels)
		{
			var ind = FindIndexInList(el);
			vars.RemoveAt(ind);
			vars.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<var_def_statement> match)
		{
			return vars.RemoveAll(match);
		}
		
		public var_def_statement Last()
		{
			return vars[vars.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			var_def_list_for_record copy = new var_def_list_for_record();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (vars != null)
			{
				foreach (var_def_statement elem in vars)
				{
					if (elem != null)
					{
						copy.Add((var_def_statement)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new var_def_list_for_record TypedClone()
		{
			return Clone() as var_def_list_for_record;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (vars != null)
			{
				foreach (var child in vars)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (vars != null)
			{
				foreach (var child in vars)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (vars == null ? 0 : vars.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(vars != null)
				{
					if(index_counter < vars.Count)
					{
						return vars[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(vars != null)
				{
					if(index_counter < vars.Count)
					{
						vars[index_counter]= (var_def_statement)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class record_type_parts : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public record_type_parts()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_type_parts(var_def_list_for_record _fixed_part,variant_record_type _variant_part)
		{
			this._fixed_part=_fixed_part;
			this._variant_part=_variant_part;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public record_type_parts(var_def_list_for_record _fixed_part,variant_record_type _variant_part,SourceContext sc)
		{
			this._fixed_part=_fixed_part;
			this._variant_part=_variant_part;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected var_def_list_for_record _fixed_part;
		protected variant_record_type _variant_part;

		///<summary>
		///
		///</summary>
		public var_def_list_for_record fixed_part
		{
			get
			{
				return _fixed_part;
			}
			set
			{
				_fixed_part=value;
			}
		}

		///<summary>
		///
		///</summary>
		public variant_record_type variant_part
		{
			get
			{
				return _variant_part;
			}
			set
			{
				_variant_part=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			record_type_parts copy = new record_type_parts();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (fixed_part != null)
			{
				copy.fixed_part = (var_def_list_for_record)fixed_part.Clone();
				copy.fixed_part.Parent = copy;
			}
			if (variant_part != null)
			{
				copy.variant_part = (variant_record_type)variant_part.Clone();
				copy.variant_part.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new record_type_parts TypedClone()
		{
			return Clone() as record_type_parts;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (fixed_part != null)
				fixed_part.Parent = this;
			if (variant_part != null)
				variant_part.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			fixed_part?.FillParentsInAllChilds();
			variant_part?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return fixed_part;
					case 1:
						return variant_part;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						fixed_part = (var_def_list_for_record)value;
						break;
					case 1:
						variant_part = (variant_record_type)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class property_array_default : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public property_array_default()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			property_array_default copy = new property_array_default();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new property_array_default TypedClone()
		{
			return Clone() as property_array_default;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class property_interface : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public property_interface()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_interface(property_parameter_list _parameter_list,type_definition _property_type,expression _index_expression)
		{
			this._parameter_list=_parameter_list;
			this._property_type=_property_type;
			this._index_expression=_index_expression;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_interface(property_parameter_list _parameter_list,type_definition _property_type,expression _index_expression,SourceContext sc)
		{
			this._parameter_list=_parameter_list;
			this._property_type=_property_type;
			this._index_expression=_index_expression;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected property_parameter_list _parameter_list;
		protected type_definition _property_type;
		protected expression _index_expression;

		///<summary>
		///
		///</summary>
		public property_parameter_list parameter_list
		{
			get
			{
				return _parameter_list;
			}
			set
			{
				_parameter_list=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition property_type
		{
			get
			{
				return _property_type;
			}
			set
			{
				_property_type=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression index_expression
		{
			get
			{
				return _index_expression;
			}
			set
			{
				_index_expression=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			property_interface copy = new property_interface();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (parameter_list != null)
			{
				copy.parameter_list = (property_parameter_list)parameter_list.Clone();
				copy.parameter_list.Parent = copy;
			}
			if (property_type != null)
			{
				copy.property_type = (type_definition)property_type.Clone();
				copy.property_type.Parent = copy;
			}
			if (index_expression != null)
			{
				copy.index_expression = (expression)index_expression.Clone();
				copy.index_expression.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new property_interface TypedClone()
		{
			return Clone() as property_interface;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (parameter_list != null)
				parameter_list.Parent = this;
			if (property_type != null)
				property_type.Parent = this;
			if (index_expression != null)
				index_expression.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			parameter_list?.FillParentsInAllChilds();
			property_type?.FillParentsInAllChilds();
			index_expression?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return parameter_list;
					case 1:
						return property_type;
					case 2:
						return index_expression;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						parameter_list = (property_parameter_list)value;
						break;
					case 1:
						property_type = (type_definition)value;
						break;
					case 2:
						index_expression = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class property_parameter : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public property_parameter()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_parameter(ident_list _names,type_definition _type)
		{
			this._names=_names;
			this._type=_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_parameter(ident_list _names,type_definition _type,SourceContext sc)
		{
			this._names=_names;
			this._type=_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _names;
		protected type_definition _type;

		///<summary>
		///
		///</summary>
		public ident_list names
		{
			get
			{
				return _names;
			}
			set
			{
				_names=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition type
		{
			get
			{
				return _type;
			}
			set
			{
				_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			property_parameter copy = new property_parameter();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (names != null)
			{
				copy.names = (ident_list)names.Clone();
				copy.names.Parent = copy;
			}
			if (type != null)
			{
				copy.type = (type_definition)type.Clone();
				copy.type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new property_parameter TypedClone()
		{
			return Clone() as property_parameter;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (names != null)
				names.Parent = this;
			if (type != null)
				type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			names?.FillParentsInAllChilds();
			type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return names;
					case 1:
						return type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						names = (ident_list)value;
						break;
					case 1:
						type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class property_parameter_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public property_parameter_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_parameter_list(List<property_parameter> _parameters)
		{
			this._parameters=_parameters;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public property_parameter_list(List<property_parameter> _parameters,SourceContext sc)
		{
			this._parameters=_parameters;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public property_parameter_list(property_parameter elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<property_parameter> _parameters=new List<property_parameter>();

		///<summary>
		///
		///</summary>
		public List<property_parameter> parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters=value;
			}
		}


		public property_parameter_list Add(property_parameter elem, SourceContext sc = null)
		{
			parameters.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(property_parameter el)
		{
			parameters.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<property_parameter> els)
		{
			parameters.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params property_parameter[] els)
		{
			parameters.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(property_parameter el)
		{
			var ind = parameters.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(property_parameter el, property_parameter newel)
		{
			parameters.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(property_parameter el, IEnumerable<property_parameter> newels)
		{
			parameters.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(property_parameter el, property_parameter newel)
		{
			parameters.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(property_parameter el, IEnumerable<property_parameter> newels)
		{
			parameters.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(property_parameter el)
		{
			return parameters.Remove(el);
		}
		
		public void ReplaceInList(property_parameter el, property_parameter newel)
		{
			parameters[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(property_parameter el, IEnumerable<property_parameter> newels)
		{
			var ind = FindIndexInList(el);
			parameters.RemoveAt(ind);
			parameters.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<property_parameter> match)
		{
			return parameters.RemoveAll(match);
		}
		
		public property_parameter Last()
		{
			return parameters[parameters.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			property_parameter_list copy = new property_parameter_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (parameters != null)
			{
				foreach (property_parameter elem in parameters)
				{
					if (elem != null)
					{
						copy.Add((property_parameter)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new property_parameter_list TypedClone()
		{
			return Clone() as property_parameter_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (parameters != null)
			{
				foreach (var child in parameters)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (parameters != null)
			{
				foreach (var child in parameters)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (parameters == null ? 0 : parameters.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(parameters != null)
				{
					if(index_counter < parameters.Count)
					{
						return parameters[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(parameters != null)
				{
					if(index_counter < parameters.Count)
					{
						parameters[index_counter]= (property_parameter)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class inherited_ident : ident
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public inherited_ident()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public inherited_ident(string _name)
		{
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public inherited_ident(string _name,SourceContext sc)
		{
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			inherited_ident copy = new inherited_ident();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new inherited_ident TypedClone()
		{
			return Clone() as inherited_ident;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///expr:1:2
	///</summary>
	[Serializable]
	public partial class format_expr : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public format_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public format_expr(expression _expr,expression _format1,expression _format2)
		{
			this._expr=_expr;
			this._format1=_format1;
			this._format2=_format2;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public format_expr(expression _expr,expression _format1,expression _format2,SourceContext sc)
		{
			this._expr=_expr;
			this._format1=_format1;
			this._format2=_format2;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _expr;
		protected expression _format1;
		protected expression _format2;

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression format1
		{
			get
			{
				return _format1;
			}
			set
			{
				_format1=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression format2
		{
			get
			{
				return _format2;
			}
			set
			{
				_format2=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			format_expr copy = new format_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			if (format1 != null)
			{
				copy.format1 = (expression)format1.Clone();
				copy.format1.Parent = copy;
			}
			if (format2 != null)
			{
				copy.format2 = (expression)format2.Clone();
				copy.format2.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new format_expr TypedClone()
		{
			return Clone() as format_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr != null)
				expr.Parent = this;
			if (format1 != null)
				format1.Parent = this;
			if (format2 != null)
				format2.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
			format1?.FillParentsInAllChilds();
			format2?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr;
					case 1:
						return format1;
					case 2:
						return format2;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr = (expression)value;
						break;
					case 1:
						format1 = (expression)value;
						break;
					case 2:
						format2 = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class initfinal_part : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public initfinal_part()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public initfinal_part(statement_list _initialization_sect,statement_list _finalization_sect)
		{
			this._initialization_sect=_initialization_sect;
			this._finalization_sect=_finalization_sect;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public initfinal_part(statement_list _initialization_sect,statement_list _finalization_sect,SourceContext sc)
		{
			this._initialization_sect=_initialization_sect;
			this._finalization_sect=_finalization_sect;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement_list _initialization_sect;
		protected statement_list _finalization_sect;

		///<summary>
		///
		///</summary>
		public statement_list initialization_sect
		{
			get
			{
				return _initialization_sect;
			}
			set
			{
				_initialization_sect=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement_list finalization_sect
		{
			get
			{
				return _finalization_sect;
			}
			set
			{
				_finalization_sect=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			initfinal_part copy = new initfinal_part();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (initialization_sect != null)
			{
				copy.initialization_sect = (statement_list)initialization_sect.Clone();
				copy.initialization_sect.Parent = copy;
			}
			if (finalization_sect != null)
			{
				copy.finalization_sect = (statement_list)finalization_sect.Clone();
				copy.finalization_sect.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new initfinal_part TypedClone()
		{
			return Clone() as initfinal_part;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (initialization_sect != null)
				initialization_sect.Parent = this;
			if (finalization_sect != null)
				finalization_sect.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			initialization_sect?.FillParentsInAllChilds();
			finalization_sect?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return initialization_sect;
					case 1:
						return finalization_sect;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						initialization_sect = (statement_list)value;
						break;
					case 1:
						finalization_sect = (statement_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class token_info : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public token_info()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public token_info(string _text)
		{
			this._text=_text;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public token_info(string _text,SourceContext sc)
		{
			this._text=_text;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected string _text;

		///<summary>
		///
		///</summary>
		public string text
		{
			get
			{
				return _text;
			}
			set
			{
				_text=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			token_info copy = new token_info();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.text = text;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new token_info TypedClone()
		{
			return Clone() as token_info;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///raise [expr [at address]]
	///</summary>
	[Serializable]
	public partial class raise_stmt : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public raise_stmt()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public raise_stmt(expression _expr,expression _address)
		{
			this._expr=_expr;
			this._address=_address;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public raise_stmt(expression _expr,expression _address,SourceContext sc)
		{
			this._expr=_expr;
			this._address=_address;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _expr;
		protected expression _address;

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression address
		{
			get
			{
				return _address;
			}
			set
			{
				_address=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			raise_stmt copy = new raise_stmt();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			if (address != null)
			{
				copy.address = (expression)address.Clone();
				copy.address.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new raise_stmt TypedClone()
		{
			return Clone() as raise_stmt;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr != null)
				expr.Parent = this;
			if (address != null)
				address.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
			address?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr;
					case 1:
						return address;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr = (expression)value;
						break;
					case 1:
						address = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class op_type_node : token_info
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public op_type_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public op_type_node(Operators _type)
		{
			this._type=_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public op_type_node(Operators _type,SourceContext sc)
		{
			this._type=_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public op_type_node(string _text,Operators _type)
		{
			this._text=_text;
			this._type=_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public op_type_node(string _text,Operators _type,SourceContext sc)
		{
			this._text=_text;
			this._type=_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected Operators _type;

		///<summary>
		///
		///</summary>
		public Operators type
		{
			get
			{
				return _type;
			}
			set
			{
				_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			op_type_node copy = new op_type_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.text = text;
			copy.type = type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new op_type_node TypedClone()
		{
			return Clone() as op_type_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class file_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public file_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type(type_definition _file_of_type)
		{
			this._file_of_type=_file_of_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type(type_definition _file_of_type,SourceContext sc)
		{
			this._file_of_type=_file_of_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type(type_definition_attr_list _attr_list,type_definition _file_of_type)
		{
			this._attr_list=_attr_list;
			this._file_of_type=_file_of_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public file_type(type_definition_attr_list _attr_list,type_definition _file_of_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._file_of_type=_file_of_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _file_of_type;

		///<summary>
		///
		///</summary>
		public type_definition file_of_type
		{
			get
			{
				return _file_of_type;
			}
			set
			{
				_file_of_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			file_type copy = new file_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (file_of_type != null)
			{
				copy.file_of_type = (type_definition)file_of_type.Clone();
				copy.file_of_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new file_type TypedClone()
		{
			return Clone() as file_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (file_of_type != null)
				file_of_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			file_of_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return file_of_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						file_of_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class known_type_ident : ident
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public known_type_ident()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_ident(known_type _type)
		{
			this._type=_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_ident(known_type _type,SourceContext sc)
		{
			this._type=_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_ident(string _name,known_type _type)
		{
			this._name=_name;
			this._type=_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public known_type_ident(string _name,known_type _type,SourceContext sc)
		{
			this._name=_name;
			this._type=_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected known_type _type;

		///<summary>
		///
		///</summary>
		public known_type type
		{
			get
			{
				return _type;
			}
			set
			{
				_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			known_type_ident copy = new known_type_ident();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			copy.type = type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new known_type_ident TypedClone()
		{
			return Clone() as known_type_ident;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class exception_handler : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public exception_handler()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_handler(ident _variable,named_type_reference _type_name,statement _statements)
		{
			this._variable=_variable;
			this._type_name=_type_name;
			this._statements=_statements;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_handler(ident _variable,named_type_reference _type_name,statement _statements,SourceContext sc)
		{
			this._variable=_variable;
			this._type_name=_type_name;
			this._statements=_statements;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _variable;
		protected named_type_reference _type_name;
		protected statement _statements;

		///<summary>
		///
		///</summary>
		public ident variable
		{
			get
			{
				return _variable;
			}
			set
			{
				_variable=value;
			}
		}

		///<summary>
		///
		///</summary>
		public named_type_reference type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement statements
		{
			get
			{
				return _statements;
			}
			set
			{
				_statements=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			exception_handler copy = new exception_handler();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (variable != null)
			{
				copy.variable = (ident)variable.Clone();
				copy.variable.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (named_type_reference)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			if (statements != null)
			{
				copy.statements = (statement)statements.Clone();
				copy.statements.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new exception_handler TypedClone()
		{
			return Clone() as exception_handler;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (variable != null)
				variable.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
			if (statements != null)
				statements.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			variable?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
			statements?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return variable;
					case 1:
						return type_name;
					case 2:
						return statements;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						variable = (ident)value;
						break;
					case 1:
						type_name = (named_type_reference)value;
						break;
					case 2:
						statements = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class exception_ident : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public exception_ident()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_ident(ident _variable,named_type_reference _type_name)
		{
			this._variable=_variable;
			this._type_name=_type_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_ident(ident _variable,named_type_reference _type_name,SourceContext sc)
		{
			this._variable=_variable;
			this._type_name=_type_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _variable;
		protected named_type_reference _type_name;

		///<summary>
		///
		///</summary>
		public ident variable
		{
			get
			{
				return _variable;
			}
			set
			{
				_variable=value;
			}
		}

		///<summary>
		///
		///</summary>
		public named_type_reference type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			exception_ident copy = new exception_ident();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (variable != null)
			{
				copy.variable = (ident)variable.Clone();
				copy.variable.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (named_type_reference)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new exception_ident TypedClone()
		{
			return Clone() as exception_ident;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (variable != null)
				variable.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			variable?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return variable;
					case 1:
						return type_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						variable = (ident)value;
						break;
					case 1:
						type_name = (named_type_reference)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class exception_handler_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public exception_handler_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_handler_list(List<exception_handler> _handlers)
		{
			this._handlers=_handlers;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_handler_list(List<exception_handler> _handlers,SourceContext sc)
		{
			this._handlers=_handlers;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public exception_handler_list(exception_handler elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<exception_handler> _handlers=new List<exception_handler>();

		///<summary>
		///
		///</summary>
		public List<exception_handler> handlers
		{
			get
			{
				return _handlers;
			}
			set
			{
				_handlers=value;
			}
		}


		public exception_handler_list Add(exception_handler elem, SourceContext sc = null)
		{
			handlers.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(exception_handler el)
		{
			handlers.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<exception_handler> els)
		{
			handlers.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params exception_handler[] els)
		{
			handlers.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(exception_handler el)
		{
			var ind = handlers.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(exception_handler el, exception_handler newel)
		{
			handlers.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(exception_handler el, IEnumerable<exception_handler> newels)
		{
			handlers.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(exception_handler el, exception_handler newel)
		{
			handlers.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(exception_handler el, IEnumerable<exception_handler> newels)
		{
			handlers.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(exception_handler el)
		{
			return handlers.Remove(el);
		}
		
		public void ReplaceInList(exception_handler el, exception_handler newel)
		{
			handlers[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(exception_handler el, IEnumerable<exception_handler> newels)
		{
			var ind = FindIndexInList(el);
			handlers.RemoveAt(ind);
			handlers.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<exception_handler> match)
		{
			return handlers.RemoveAll(match);
		}
		
		public exception_handler Last()
		{
			return handlers[handlers.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			exception_handler_list copy = new exception_handler_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (handlers != null)
			{
				foreach (exception_handler elem in handlers)
				{
					if (elem != null)
					{
						copy.Add((exception_handler)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new exception_handler_list TypedClone()
		{
			return Clone() as exception_handler_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (handlers != null)
			{
				foreach (var child in handlers)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (handlers != null)
			{
				foreach (var child in handlers)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (handlers == null ? 0 : handlers.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(handlers != null)
				{
					if(index_counter < handlers.Count)
					{
						return handlers[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(handlers != null)
				{
					if(index_counter < handlers.Count)
					{
						handlers[index_counter]= (exception_handler)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class exception_block : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public exception_block()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_block(statement_list _stmt_list,exception_handler_list _handlers,statement_list _else_stmt_list)
		{
			this._stmt_list=_stmt_list;
			this._handlers=_handlers;
			this._else_stmt_list=_else_stmt_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public exception_block(statement_list _stmt_list,exception_handler_list _handlers,statement_list _else_stmt_list,SourceContext sc)
		{
			this._stmt_list=_stmt_list;
			this._handlers=_handlers;
			this._else_stmt_list=_else_stmt_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement_list _stmt_list;
		protected exception_handler_list _handlers;
		protected statement_list _else_stmt_list;

		///<summary>
		///
		///</summary>
		public statement_list stmt_list
		{
			get
			{
				return _stmt_list;
			}
			set
			{
				_stmt_list=value;
			}
		}

		///<summary>
		///
		///</summary>
		public exception_handler_list handlers
		{
			get
			{
				return _handlers;
			}
			set
			{
				_handlers=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement_list else_stmt_list
		{
			get
			{
				return _else_stmt_list;
			}
			set
			{
				_else_stmt_list=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			exception_block copy = new exception_block();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (stmt_list != null)
			{
				copy.stmt_list = (statement_list)stmt_list.Clone();
				copy.stmt_list.Parent = copy;
			}
			if (handlers != null)
			{
				copy.handlers = (exception_handler_list)handlers.Clone();
				copy.handlers.Parent = copy;
			}
			if (else_stmt_list != null)
			{
				copy.else_stmt_list = (statement_list)else_stmt_list.Clone();
				copy.else_stmt_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new exception_block TypedClone()
		{
			return Clone() as exception_block;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (stmt_list != null)
				stmt_list.Parent = this;
			if (handlers != null)
				handlers.Parent = this;
			if (else_stmt_list != null)
				else_stmt_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			stmt_list?.FillParentsInAllChilds();
			handlers?.FillParentsInAllChilds();
			else_stmt_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return stmt_list;
					case 1:
						return handlers;
					case 2:
						return else_stmt_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						stmt_list = (statement_list)value;
						break;
					case 1:
						handlers = (exception_handler_list)value;
						break;
					case 2:
						else_stmt_list = (statement_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class try_handler : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public try_handler()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			try_handler copy = new try_handler();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new try_handler TypedClone()
		{
			return Clone() as try_handler;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class try_handler_finally : try_handler
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public try_handler_finally()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public try_handler_finally(statement_list _stmt_list)
		{
			this._stmt_list=_stmt_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public try_handler_finally(statement_list _stmt_list,SourceContext sc)
		{
			this._stmt_list=_stmt_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement_list _stmt_list;

		///<summary>
		///
		///</summary>
		public statement_list stmt_list
		{
			get
			{
				return _stmt_list;
			}
			set
			{
				_stmt_list=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			try_handler_finally copy = new try_handler_finally();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (stmt_list != null)
			{
				copy.stmt_list = (statement_list)stmt_list.Clone();
				copy.stmt_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new try_handler_finally TypedClone()
		{
			return Clone() as try_handler_finally;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (stmt_list != null)
				stmt_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			stmt_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return stmt_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						stmt_list = (statement_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class try_handler_except : try_handler
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public try_handler_except()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public try_handler_except(exception_block _except_block)
		{
			this._except_block=_except_block;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public try_handler_except(exception_block _except_block,SourceContext sc)
		{
			this._except_block=_except_block;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected exception_block _except_block;

		///<summary>
		///
		///</summary>
		public exception_block except_block
		{
			get
			{
				return _except_block;
			}
			set
			{
				_except_block=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			try_handler_except copy = new try_handler_except();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (except_block != null)
			{
				copy.except_block = (exception_block)except_block.Clone();
				copy.except_block.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new try_handler_except TypedClone()
		{
			return Clone() as try_handler_except;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (except_block != null)
				except_block.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			except_block?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return except_block;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						except_block = (exception_block)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class try_stmt : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public try_stmt()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public try_stmt(statement_list _stmt_list,try_handler _handler)
		{
			this._stmt_list=_stmt_list;
			this._handler=_handler;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public try_stmt(statement_list _stmt_list,try_handler _handler,SourceContext sc)
		{
			this._stmt_list=_stmt_list;
			this._handler=_handler;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement_list _stmt_list;
		protected try_handler _handler;

		///<summary>
		///
		///</summary>
		public statement_list stmt_list
		{
			get
			{
				return _stmt_list;
			}
			set
			{
				_stmt_list=value;
			}
		}

		///<summary>
		///
		///</summary>
		public try_handler handler
		{
			get
			{
				return _handler;
			}
			set
			{
				_handler=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			try_stmt copy = new try_stmt();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (stmt_list != null)
			{
				copy.stmt_list = (statement_list)stmt_list.Clone();
				copy.stmt_list.Parent = copy;
			}
			if (handler != null)
			{
				copy.handler = (try_handler)handler.Clone();
				copy.handler.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new try_stmt TypedClone()
		{
			return Clone() as try_stmt;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (stmt_list != null)
				stmt_list.Parent = this;
			if (handler != null)
				handler.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			stmt_list?.FillParentsInAllChilds();
			handler?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return stmt_list;
					case 1:
						return handler;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						stmt_list = (statement_list)value;
						break;
					case 1:
						handler = (try_handler)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class inherited_message : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public inherited_message()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			inherited_message copy = new inherited_message();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new inherited_message TypedClone()
		{
			return Clone() as inherited_message;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///expression может быть literal или ident
	///</summary>
	[Serializable]
	public partial class external_directive : proc_block
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public external_directive()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public external_directive(expression _modulename,expression _name)
		{
			this._modulename=_modulename;
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public external_directive(expression _modulename,expression _name,SourceContext sc)
		{
			this._modulename=_modulename;
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _modulename;
		protected expression _name;

		///<summary>
		///
		///</summary>
		public expression modulename
		{
			get
			{
				return _modulename;
			}
			set
			{
				_modulename=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			external_directive copy = new external_directive();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (modulename != null)
			{
				copy.modulename = (expression)modulename.Clone();
				copy.modulename.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (expression)name.Clone();
				copy.name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new external_directive TypedClone()
		{
			return Clone() as external_directive;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (modulename != null)
				modulename.Parent = this;
			if (name != null)
				name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			modulename?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return modulename;
					case 1:
						return name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						modulename = (expression)value;
						break;
					case 1:
						name = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class using_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public using_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public using_list(List<unit_or_namespace> _namespaces)
		{
			this._namespaces=_namespaces;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public using_list(List<unit_or_namespace> _namespaces,SourceContext sc)
		{
			this._namespaces=_namespaces;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public using_list(unit_or_namespace elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<unit_or_namespace> _namespaces=new List<unit_or_namespace>();

		///<summary>
		///
		///</summary>
		public List<unit_or_namespace> namespaces
		{
			get
			{
				return _namespaces;
			}
			set
			{
				_namespaces=value;
			}
		}


		public using_list Add(unit_or_namespace elem, SourceContext sc = null)
		{
			namespaces.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(unit_or_namespace el)
		{
			namespaces.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<unit_or_namespace> els)
		{
			namespaces.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params unit_or_namespace[] els)
		{
			namespaces.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(unit_or_namespace el)
		{
			var ind = namespaces.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(unit_or_namespace el, unit_or_namespace newel)
		{
			namespaces.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(unit_or_namespace el, IEnumerable<unit_or_namespace> newels)
		{
			namespaces.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(unit_or_namespace el, unit_or_namespace newel)
		{
			namespaces.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(unit_or_namespace el, IEnumerable<unit_or_namespace> newels)
		{
			namespaces.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(unit_or_namespace el)
		{
			return namespaces.Remove(el);
		}
		
		public void ReplaceInList(unit_or_namespace el, unit_or_namespace newel)
		{
			namespaces[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(unit_or_namespace el, IEnumerable<unit_or_namespace> newels)
		{
			var ind = FindIndexInList(el);
			namespaces.RemoveAt(ind);
			namespaces.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<unit_or_namespace> match)
		{
			return namespaces.RemoveAll(match);
		}
		
		public unit_or_namespace Last()
		{
			return namespaces[namespaces.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			using_list copy = new using_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (namespaces != null)
			{
				foreach (unit_or_namespace elem in namespaces)
				{
					if (elem != null)
					{
						copy.Add((unit_or_namespace)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new using_list TypedClone()
		{
			return Clone() as using_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (namespaces != null)
			{
				foreach (var child in namespaces)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (namespaces != null)
			{
				foreach (var child in namespaces)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (namespaces == null ? 0 : namespaces.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(namespaces != null)
				{
					if(index_counter < namespaces.Count)
					{
						return namespaces[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(namespaces != null)
				{
					if(index_counter < namespaces.Count)
					{
						namespaces[index_counter]= (unit_or_namespace)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class jump_stmt : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public jump_stmt()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public jump_stmt(expression _expr,JumpStmtType _JumpType)
		{
			this._expr=_expr;
			this._JumpType=_JumpType;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public jump_stmt(expression _expr,JumpStmtType _JumpType,SourceContext sc)
		{
			this._expr=_expr;
			this._JumpType=_JumpType;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _expr;
		protected JumpStmtType _JumpType;

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}

		///<summary>
		///
		///</summary>
		public JumpStmtType JumpType
		{
			get
			{
				return _JumpType;
			}
			set
			{
				_JumpType=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			jump_stmt copy = new jump_stmt();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			copy.JumpType = JumpType;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new jump_stmt TypedClone()
		{
			return Clone() as jump_stmt;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class loop_stmt : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public loop_stmt()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public loop_stmt(statement _stmt)
		{
			this._stmt=_stmt;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public loop_stmt(statement _stmt,SourceContext sc)
		{
			this._stmt=_stmt;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement _stmt;

		///<summary>
		///
		///</summary>
		public statement stmt
		{
			get
			{
				return _stmt;
			}
			set
			{
				_stmt=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			loop_stmt copy = new loop_stmt();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (stmt != null)
			{
				copy.stmt = (statement)stmt.Clone();
				copy.stmt.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new loop_stmt TypedClone()
		{
			return Clone() as loop_stmt;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (stmt != null)
				stmt.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			stmt?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return stmt;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						stmt = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class foreach_stmt : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public foreach_stmt()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public foreach_stmt(ident _identifier,type_definition _type_name,expression _in_what,statement _stmt)
		{
			this._identifier=_identifier;
			this._type_name=_type_name;
			this._in_what=_in_what;
			this._stmt=_stmt;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public foreach_stmt(ident _identifier,type_definition _type_name,expression _in_what,statement _stmt,SourceContext sc)
		{
			this._identifier=_identifier;
			this._type_name=_type_name;
			this._in_what=_in_what;
			this._stmt=_stmt;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _identifier;
		protected type_definition _type_name;
		protected expression _in_what;
		protected statement _stmt;

		///<summary>
		///
		///</summary>
		public ident identifier
		{
			get
			{
				return _identifier;
			}
			set
			{
				_identifier=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression in_what
		{
			get
			{
				return _in_what;
			}
			set
			{
				_in_what=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement stmt
		{
			get
			{
				return _stmt;
			}
			set
			{
				_stmt=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			foreach_stmt copy = new foreach_stmt();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (identifier != null)
			{
				copy.identifier = (ident)identifier.Clone();
				copy.identifier.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (type_definition)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			if (in_what != null)
			{
				copy.in_what = (expression)in_what.Clone();
				copy.in_what.Parent = copy;
			}
			if (stmt != null)
			{
				copy.stmt = (statement)stmt.Clone();
				copy.stmt.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new foreach_stmt TypedClone()
		{
			return Clone() as foreach_stmt;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (identifier != null)
				identifier.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
			if (in_what != null)
				in_what.Parent = this;
			if (stmt != null)
				stmt.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			identifier?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
			in_what?.FillParentsInAllChilds();
			stmt?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return identifier;
					case 1:
						return type_name;
					case 2:
						return in_what;
					case 3:
						return stmt;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						identifier = (ident)value;
						break;
					case 1:
						type_name = (type_definition)value;
						break;
					case 2:
						in_what = (expression)value;
						break;
					case 3:
						stmt = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class addressed_value_funcname : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public addressed_value_funcname()
		{

		}

		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			addressed_value_funcname copy = new addressed_value_funcname();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new addressed_value_funcname TypedClone()
		{
			return Clone() as addressed_value_funcname;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class named_type_reference_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public named_type_reference_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public named_type_reference_list(List<named_type_reference> _types)
		{
			this._types=_types;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public named_type_reference_list(List<named_type_reference> _types,SourceContext sc)
		{
			this._types=_types;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public named_type_reference_list(named_type_reference elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<named_type_reference> _types=new List<named_type_reference>();

		///<summary>
		///
		///</summary>
		public List<named_type_reference> types
		{
			get
			{
				return _types;
			}
			set
			{
				_types=value;
			}
		}


		public named_type_reference_list Add(named_type_reference elem, SourceContext sc = null)
		{
			types.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(named_type_reference el)
		{
			types.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<named_type_reference> els)
		{
			types.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params named_type_reference[] els)
		{
			types.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(named_type_reference el)
		{
			var ind = types.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(named_type_reference el, named_type_reference newel)
		{
			types.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(named_type_reference el, IEnumerable<named_type_reference> newels)
		{
			types.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(named_type_reference el, named_type_reference newel)
		{
			types.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(named_type_reference el, IEnumerable<named_type_reference> newels)
		{
			types.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(named_type_reference el)
		{
			return types.Remove(el);
		}
		
		public void ReplaceInList(named_type_reference el, named_type_reference newel)
		{
			types[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(named_type_reference el, IEnumerable<named_type_reference> newels)
		{
			var ind = FindIndexInList(el);
			types.RemoveAt(ind);
			types.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<named_type_reference> match)
		{
			return types.RemoveAll(match);
		}
		
		public named_type_reference Last()
		{
			return types[types.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			named_type_reference_list copy = new named_type_reference_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (types != null)
			{
				foreach (named_type_reference elem in types)
				{
					if (elem != null)
					{
						copy.Add((named_type_reference)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new named_type_reference_list TypedClone()
		{
			return Clone() as named_type_reference_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (types != null)
			{
				foreach (var child in types)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (types != null)
			{
				foreach (var child in types)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (types == null ? 0 : types.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(types != null)
				{
					if(index_counter < types.Count)
					{
						return types[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(types != null)
				{
					if(index_counter < types.Count)
					{
						types[index_counter]= (named_type_reference)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class template_param_list : dereference
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public template_param_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_param_list(List<type_definition> _params_list)
		{
			this._params_list=_params_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_param_list(List<type_definition> _params_list,SourceContext sc)
		{
			this._params_list=_params_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_param_list(addressed_value _dereferencing_value,List<type_definition> _params_list)
		{
			this._dereferencing_value=_dereferencing_value;
			this._params_list=_params_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_param_list(addressed_value _dereferencing_value,List<type_definition> _params_list,SourceContext sc)
		{
			this._dereferencing_value=_dereferencing_value;
			this._params_list=_params_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public template_param_list(type_definition elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<type_definition> _params_list=new List<type_definition>();

		///<summary>
		///
		///</summary>
		public List<type_definition> params_list
		{
			get
			{
				return _params_list;
			}
			set
			{
				_params_list=value;
			}
		}


		public template_param_list Add(type_definition elem, SourceContext sc = null)
		{
			params_list.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(type_definition el)
		{
			params_list.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<type_definition> els)
		{
			params_list.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params type_definition[] els)
		{
			params_list.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(type_definition el)
		{
			var ind = params_list.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(type_definition el, type_definition newel)
		{
			params_list.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(type_definition el, IEnumerable<type_definition> newels)
		{
			params_list.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(type_definition el, type_definition newel)
		{
			params_list.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(type_definition el, IEnumerable<type_definition> newels)
		{
			params_list.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(type_definition el)
		{
			return params_list.Remove(el);
		}
		
		public void ReplaceInList(type_definition el, type_definition newel)
		{
			params_list[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(type_definition el, IEnumerable<type_definition> newels)
		{
			var ind = FindIndexInList(el);
			params_list.RemoveAt(ind);
			params_list.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<type_definition> match)
		{
			return params_list.RemoveAll(match);
		}
		
		public type_definition Last()
		{
			return params_list[params_list.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			template_param_list copy = new template_param_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (dereferencing_value != null)
			{
				copy.dereferencing_value = (addressed_value)dereferencing_value.Clone();
				copy.dereferencing_value.Parent = copy;
			}
			if (params_list != null)
			{
				foreach (type_definition elem in params_list)
				{
					if (elem != null)
					{
						copy.Add((type_definition)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new template_param_list TypedClone()
		{
			return Clone() as template_param_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (dereferencing_value != null)
				dereferencing_value.Parent = this;
			if (params_list != null)
			{
				foreach (var child in params_list)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			dereferencing_value?.FillParentsInAllChilds();
			if (params_list != null)
			{
				foreach (var child in params_list)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1 + (params_list == null ? 0 : params_list.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return dereferencing_value;
				}
				Int32 index_counter=ind - 1;
				if(params_list != null)
				{
					if(index_counter < params_list.Count)
					{
						return params_list[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						dereferencing_value = (addressed_value)value;
						break;
				}
				Int32 index_counter=ind - 1;
				if(params_list != null)
				{
					if(index_counter < params_list.Count)
					{
						params_list[index_counter]= (type_definition)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class template_type_reference : named_type_reference
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public template_type_reference()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_reference(named_type_reference _name,template_param_list _params_list)
		{
			this._name=_name;
			this._params_list=_params_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_reference(named_type_reference _name,template_param_list _params_list,SourceContext sc)
		{
			this._name=_name;
			this._params_list=_params_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_reference(type_definition_attr_list _attr_list,List<ident> _names,named_type_reference _name,template_param_list _params_list)
		{
			this._attr_list=_attr_list;
			this._names=_names;
			this._name=_name;
			this._params_list=_params_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_reference(type_definition_attr_list _attr_list,List<ident> _names,named_type_reference _name,template_param_list _params_list,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._names=_names;
			this._name=_name;
			this._params_list=_params_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected named_type_reference _name;
		protected template_param_list _params_list;

		///<summary>
		///
		///</summary>
		public named_type_reference name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public template_param_list params_list
		{
			get
			{
				return _params_list;
			}
			set
			{
				_params_list=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			template_type_reference copy = new template_type_reference();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (names != null)
			{
				foreach (ident elem in names)
				{
					if (elem != null)
					{
						copy.Add((ident)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			if (name != null)
			{
				copy.name = (named_type_reference)name.Clone();
				copy.name.Parent = copy;
			}
			if (params_list != null)
			{
				copy.params_list = (template_param_list)params_list.Clone();
				copy.params_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new template_type_reference TypedClone()
		{
			return Clone() as template_type_reference;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (names != null)
			{
				foreach (var child in names)
					if (child != null)
						child.Parent = this;
			}
			if (name != null)
				name.Parent = this;
			if (params_list != null)
				params_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			if (names != null)
			{
				foreach (var child in names)
					child?.FillParentsInAllChilds();
			}
			name?.FillParentsInAllChilds();
			params_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3 + (names == null ? 0 : names.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return name;
					case 2:
						return params_list;
				}
				Int32 index_counter=ind - 3;
				if(names != null)
				{
					if(index_counter < names.Count)
					{
						return names[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						name = (named_type_reference)value;
						break;
					case 2:
						params_list = (template_param_list)value;
						break;
				}
				Int32 index_counter=ind - 3;
				if(names != null)
				{
					if(index_counter < names.Count)
					{
						names[index_counter]= (ident)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class int64_const : const_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public int64_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public int64_const(Int64 _val)
		{
			this._val=_val;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public int64_const(Int64 _val,SourceContext sc)
		{
			this._val=_val;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected Int64 _val;

		///<summary>
		///
		///</summary>
		public Int64 val
		{
			get
			{
				return _val;
			}
			set
			{
				_val=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			int64_const copy = new int64_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.val = val;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new int64_const TypedClone()
		{
			return Clone() as int64_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class uint64_const : const_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public uint64_const()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uint64_const(UInt64 _val)
		{
			this._val=_val;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uint64_const(UInt64 _val,SourceContext sc)
		{
			this._val=_val;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected UInt64 _val;

		///<summary>
		///
		///</summary>
		public UInt64 val
		{
			get
			{
				return _val;
			}
			set
			{
				_val=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			uint64_const copy = new uint64_const();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.val = val;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new uint64_const TypedClone()
		{
			return Clone() as uint64_const;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class new_expr : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public new_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public new_expr(type_definition _type,expression_list _params_list,bool _new_array,array_const _array_init_expr)
		{
			this._type=_type;
			this._params_list=_params_list;
			this._new_array=_new_array;
			this._array_init_expr=_array_init_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public new_expr(type_definition _type,expression_list _params_list,bool _new_array,array_const _array_init_expr,SourceContext sc)
		{
			this._type=_type;
			this._params_list=_params_list;
			this._new_array=_new_array;
			this._array_init_expr=_array_init_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _type;
		protected expression_list _params_list;
		protected bool _new_array;
		protected array_const _array_init_expr;

		///<summary>
		///
		///</summary>
		public type_definition type
		{
			get
			{
				return _type;
			}
			set
			{
				_type=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression_list params_list
		{
			get
			{
				return _params_list;
			}
			set
			{
				_params_list=value;
			}
		}

		///<summary>
		///
		///</summary>
		public bool new_array
		{
			get
			{
				return _new_array;
			}
			set
			{
				_new_array=value;
			}
		}

		///<summary>
		///
		///</summary>
		public array_const array_init_expr
		{
			get
			{
				return _array_init_expr;
			}
			set
			{
				_array_init_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			new_expr copy = new new_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (type != null)
			{
				copy.type = (type_definition)type.Clone();
				copy.type.Parent = copy;
			}
			if (params_list != null)
			{
				copy.params_list = (expression_list)params_list.Clone();
				copy.params_list.Parent = copy;
			}
			copy.new_array = new_array;
			if (array_init_expr != null)
			{
				copy.array_init_expr = (array_const)array_init_expr.Clone();
				copy.array_init_expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new new_expr TypedClone()
		{
			return Clone() as new_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (type != null)
				type.Parent = this;
			if (params_list != null)
				params_list.Parent = this;
			if (array_init_expr != null)
				array_init_expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			type?.FillParentsInAllChilds();
			params_list?.FillParentsInAllChilds();
			array_init_expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return type;
					case 1:
						return params_list;
					case 2:
						return array_init_expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						type = (type_definition)value;
						break;
					case 1:
						params_list = (expression_list)value;
						break;
					case 2:
						array_init_expr = (array_const)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class where_type_specificator_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public where_type_specificator_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public where_type_specificator_list(List<type_definition> _defs)
		{
			this._defs=_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public where_type_specificator_list(List<type_definition> _defs,SourceContext sc)
		{
			this._defs=_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public where_type_specificator_list(type_definition elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<type_definition> _defs=new List<type_definition>();

		///<summary>
		///
		///</summary>
		public List<type_definition> defs
		{
			get
			{
				return _defs;
			}
			set
			{
				_defs=value;
			}
		}


		public where_type_specificator_list Add(type_definition elem, SourceContext sc = null)
		{
			defs.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(type_definition el)
		{
			defs.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<type_definition> els)
		{
			defs.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params type_definition[] els)
		{
			defs.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(type_definition el)
		{
			var ind = defs.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(type_definition el, type_definition newel)
		{
			defs.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(type_definition el, IEnumerable<type_definition> newels)
		{
			defs.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(type_definition el, type_definition newel)
		{
			defs.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(type_definition el, IEnumerable<type_definition> newels)
		{
			defs.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(type_definition el)
		{
			return defs.Remove(el);
		}
		
		public void ReplaceInList(type_definition el, type_definition newel)
		{
			defs[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(type_definition el, IEnumerable<type_definition> newels)
		{
			var ind = FindIndexInList(el);
			defs.RemoveAt(ind);
			defs.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<type_definition> match)
		{
			return defs.RemoveAll(match);
		}
		
		public type_definition Last()
		{
			return defs[defs.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			where_type_specificator_list copy = new where_type_specificator_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (defs != null)
			{
				foreach (type_definition elem in defs)
				{
					if (elem != null)
					{
						copy.Add((type_definition)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new where_type_specificator_list TypedClone()
		{
			return Clone() as where_type_specificator_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (defs != null)
			{
				foreach (var child in defs)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (defs != null)
			{
				foreach (var child in defs)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (defs == null ? 0 : defs.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						return defs[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						defs[index_counter]= (type_definition)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class where_definition : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public where_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public where_definition(ident_list _names,where_type_specificator_list _types)
		{
			this._names=_names;
			this._types=_types;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public where_definition(ident_list _names,where_type_specificator_list _types,SourceContext sc)
		{
			this._names=_names;
			this._types=_types;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _names;
		protected where_type_specificator_list _types;

		///<summary>
		///
		///</summary>
		public ident_list names
		{
			get
			{
				return _names;
			}
			set
			{
				_names=value;
			}
		}

		///<summary>
		///
		///</summary>
		public where_type_specificator_list types
		{
			get
			{
				return _types;
			}
			set
			{
				_types=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			where_definition copy = new where_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (names != null)
			{
				copy.names = (ident_list)names.Clone();
				copy.names.Parent = copy;
			}
			if (types != null)
			{
				copy.types = (where_type_specificator_list)types.Clone();
				copy.types.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new where_definition TypedClone()
		{
			return Clone() as where_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (names != null)
				names.Parent = this;
			if (types != null)
				types.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			names?.FillParentsInAllChilds();
			types?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return names;
					case 1:
						return types;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						names = (ident_list)value;
						break;
					case 1:
						types = (where_type_specificator_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class where_definition_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public where_definition_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public where_definition_list(List<where_definition> _defs)
		{
			this._defs=_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public where_definition_list(List<where_definition> _defs,SourceContext sc)
		{
			this._defs=_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public where_definition_list(where_definition elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<where_definition> _defs=new List<where_definition>();

		///<summary>
		///
		///</summary>
		public List<where_definition> defs
		{
			get
			{
				return _defs;
			}
			set
			{
				_defs=value;
			}
		}


		public where_definition_list Add(where_definition elem, SourceContext sc = null)
		{
			defs.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(where_definition el)
		{
			defs.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<where_definition> els)
		{
			defs.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params where_definition[] els)
		{
			defs.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(where_definition el)
		{
			var ind = defs.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(where_definition el, where_definition newel)
		{
			defs.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(where_definition el, IEnumerable<where_definition> newels)
		{
			defs.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(where_definition el, where_definition newel)
		{
			defs.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(where_definition el, IEnumerable<where_definition> newels)
		{
			defs.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(where_definition el)
		{
			return defs.Remove(el);
		}
		
		public void ReplaceInList(where_definition el, where_definition newel)
		{
			defs[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(where_definition el, IEnumerable<where_definition> newels)
		{
			var ind = FindIndexInList(el);
			defs.RemoveAt(ind);
			defs.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<where_definition> match)
		{
			return defs.RemoveAll(match);
		}
		
		public where_definition Last()
		{
			return defs[defs.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			where_definition_list copy = new where_definition_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (defs != null)
			{
				foreach (where_definition elem in defs)
				{
					if (elem != null)
					{
						copy.Add((where_definition)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new where_definition_list TypedClone()
		{
			return Clone() as where_definition_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (defs != null)
			{
				foreach (var child in defs)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (defs != null)
			{
				foreach (var child in defs)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (defs == null ? 0 : defs.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						return defs[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						defs[index_counter]= (where_definition)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class sizeof_operator : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public sizeof_operator()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sizeof_operator(type_definition _type_def,expression _expr)
		{
			this._type_def=_type_def;
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sizeof_operator(type_definition _type_def,expression _expr,SourceContext sc)
		{
			this._type_def=_type_def;
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _type_def;
		protected expression _expr;

		///<summary>
		///
		///</summary>
		public type_definition type_def
		{
			get
			{
				return _type_def;
			}
			set
			{
				_type_def=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			sizeof_operator copy = new sizeof_operator();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (type_def != null)
			{
				copy.type_def = (type_definition)type_def.Clone();
				copy.type_def.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new sizeof_operator TypedClone()
		{
			return Clone() as sizeof_operator;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (type_def != null)
				type_def.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			type_def?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return type_def;
					case 1:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						type_def = (type_definition)value;
						break;
					case 1:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class typeof_operator : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public typeof_operator()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typeof_operator(named_type_reference _type_name)
		{
			this._type_name=_type_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public typeof_operator(named_type_reference _type_name,SourceContext sc)
		{
			this._type_name=_type_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected named_type_reference _type_name;

		///<summary>
		///
		///</summary>
		public named_type_reference type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			typeof_operator copy = new typeof_operator();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (named_type_reference)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new typeof_operator TypedClone()
		{
			return Clone() as typeof_operator;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return type_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						type_name = (named_type_reference)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class compiler_directive : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public compiler_directive()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive(token_info _Name,token_info _Directive)
		{
			this._Name=_Name;
			this._Directive=_Directive;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive(token_info _Name,token_info _Directive,SourceContext sc)
		{
			this._Name=_Name;
			this._Directive=_Directive;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected token_info _Name;
		protected token_info _Directive;

		///<summary>
		///
		///</summary>
		public token_info Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public token_info Directive
		{
			get
			{
				return _Directive;
			}
			set
			{
				_Directive=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			compiler_directive copy = new compiler_directive();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (Name != null)
			{
				copy.Name = (token_info)Name.Clone();
				copy.Name.Parent = copy;
			}
			if (Directive != null)
			{
				copy.Directive = (token_info)Directive.Clone();
				copy.Directive.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new compiler_directive TypedClone()
		{
			return Clone() as compiler_directive;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (Name != null)
				Name.Parent = this;
			if (Directive != null)
				Directive.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			Name?.FillParentsInAllChilds();
			Directive?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return Name;
					case 1:
						return Directive;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						Name = (token_info)value;
						break;
					case 1:
						Directive = (token_info)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class operator_name_ident : ident
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public operator_name_ident()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public operator_name_ident(Operators _operator_type)
		{
			this._operator_type=_operator_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public operator_name_ident(Operators _operator_type,SourceContext sc)
		{
			this._operator_type=_operator_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public operator_name_ident(string _name,Operators _operator_type)
		{
			this._name=_name;
			this._operator_type=_operator_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public operator_name_ident(string _name,Operators _operator_type,SourceContext sc)
		{
			this._name=_name;
			this._operator_type=_operator_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected Operators _operator_type;

		///<summary>
		///
		///</summary>
		public Operators operator_type
		{
			get
			{
				return _operator_type;
			}
			set
			{
				_operator_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			operator_name_ident copy = new operator_name_ident();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			copy.operator_type = operator_type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new operator_name_ident TypedClone()
		{
			return Clone() as operator_name_ident;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Однострочное описание переменной внутри begin-end. Хранит внутри var_def_statement
	///</summary>
	[Serializable]
	public partial class var_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public var_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public var_statement(var_def_statement _var_def)
		{
			this._var_def=_var_def;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public var_statement(var_def_statement _var_def,SourceContext sc)
		{
			this._var_def=_var_def;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected var_def_statement _var_def;

		///<summary>
		///
		///</summary>
		public var_def_statement var_def
		{
			get
			{
				return _var_def;
			}
			set
			{
				_var_def=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			var_statement copy = new var_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (var_def != null)
			{
				copy.var_def = (var_def_statement)var_def.Clone();
				copy.var_def.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new var_statement TypedClone()
		{
			return Clone() as var_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (var_def != null)
				var_def.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			var_def?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return var_def;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						var_def = (var_def_statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class question_colon_expression : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public question_colon_expression()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public question_colon_expression(expression _condition,expression _ret_if_true,expression _ret_if_false)
		{
			this._condition=_condition;
			this._ret_if_true=_ret_if_true;
			this._ret_if_false=_ret_if_false;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public question_colon_expression(expression _condition,expression _ret_if_true,expression _ret_if_false,SourceContext sc)
		{
			this._condition=_condition;
			this._ret_if_true=_ret_if_true;
			this._ret_if_false=_ret_if_false;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _condition;
		protected expression _ret_if_true;
		protected expression _ret_if_false;

		///<summary>
		///
		///</summary>
		public expression condition
		{
			get
			{
				return _condition;
			}
			set
			{
				_condition=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression ret_if_true
		{
			get
			{
				return _ret_if_true;
			}
			set
			{
				_ret_if_true=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression ret_if_false
		{
			get
			{
				return _ret_if_false;
			}
			set
			{
				_ret_if_false=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			question_colon_expression copy = new question_colon_expression();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (condition != null)
			{
				copy.condition = (expression)condition.Clone();
				copy.condition.Parent = copy;
			}
			if (ret_if_true != null)
			{
				copy.ret_if_true = (expression)ret_if_true.Clone();
				copy.ret_if_true.Parent = copy;
			}
			if (ret_if_false != null)
			{
				copy.ret_if_false = (expression)ret_if_false.Clone();
				copy.ret_if_false.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new question_colon_expression TypedClone()
		{
			return Clone() as question_colon_expression;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (condition != null)
				condition.Parent = this;
			if (ret_if_true != null)
				ret_if_true.Parent = this;
			if (ret_if_false != null)
				ret_if_false.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			condition?.FillParentsInAllChilds();
			ret_if_true?.FillParentsInAllChilds();
			ret_if_false?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return condition;
					case 1:
						return ret_if_true;
					case 2:
						return ret_if_false;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						condition = (expression)value;
						break;
					case 1:
						ret_if_true = (expression)value;
						break;
					case 2:
						ret_if_false = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class expression_as_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public expression_as_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public expression_as_statement(expression _expr)
		{
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public expression_as_statement(expression _expr,SourceContext sc)
		{
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _expr;

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			expression_as_statement copy = new expression_as_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new expression_as_statement TypedClone()
		{
			return Clone() as expression_as_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class c_scalar_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public c_scalar_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_scalar_type(c_scalar_type_name _scalar_name,c_scalar_sign _sign)
		{
			this._scalar_name=_scalar_name;
			this._sign=_sign;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_scalar_type(c_scalar_type_name _scalar_name,c_scalar_sign _sign,SourceContext sc)
		{
			this._scalar_name=_scalar_name;
			this._sign=_sign;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_scalar_type(type_definition_attr_list _attr_list,c_scalar_type_name _scalar_name,c_scalar_sign _sign)
		{
			this._attr_list=_attr_list;
			this._scalar_name=_scalar_name;
			this._sign=_sign;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_scalar_type(type_definition_attr_list _attr_list,c_scalar_type_name _scalar_name,c_scalar_sign _sign,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._scalar_name=_scalar_name;
			this._sign=_sign;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected c_scalar_type_name _scalar_name;
		protected c_scalar_sign _sign;

		///<summary>
		///
		///</summary>
		public c_scalar_type_name scalar_name
		{
			get
			{
				return _scalar_name;
			}
			set
			{
				_scalar_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public c_scalar_sign sign
		{
			get
			{
				return _sign;
			}
			set
			{
				_sign=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			c_scalar_type copy = new c_scalar_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			copy.scalar_name = scalar_name;
			copy.sign = sign;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new c_scalar_type TypedClone()
		{
			return Clone() as c_scalar_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class c_module : compilation_unit
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public c_module()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_module(declarations _defs,uses_list _used_units)
		{
			this._defs=_defs;
			this._used_units=_used_units;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_module(declarations _defs,uses_list _used_units,SourceContext sc)
		{
			this._defs=_defs;
			this._used_units=_used_units;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_module(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language,declarations _defs,uses_list _used_units)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			this._defs=_defs;
			this._used_units=_used_units;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_module(string _file_name,List<compiler_directive> _compiler_directives,LanguageId _Language,declarations _defs,uses_list _used_units,SourceContext sc)
		{
			this._file_name=_file_name;
			this._compiler_directives=_compiler_directives;
			this._Language=_Language;
			this._defs=_defs;
			this._used_units=_used_units;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected declarations _defs;
		protected uses_list _used_units;

		///<summary>
		///
		///</summary>
		public declarations defs
		{
			get
			{
				return _defs;
			}
			set
			{
				_defs=value;
			}
		}

		///<summary>
		///
		///</summary>
		public uses_list used_units
		{
			get
			{
				return _used_units;
			}
			set
			{
				_used_units=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			c_module copy = new c_module();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.file_name = file_name;
			if (compiler_directives != null)
			{
				foreach (compiler_directive elem in compiler_directives)
				{
					if (elem != null)
					{
						copy.Add((compiler_directive)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.Language = Language;
			if (defs != null)
			{
				copy.defs = (declarations)defs.Clone();
				copy.defs.Parent = copy;
			}
			if (used_units != null)
			{
				copy.used_units = (uses_list)used_units.Clone();
				copy.used_units.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new c_module TypedClone()
		{
			return Clone() as c_module;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					if (child != null)
						child.Parent = this;
			}
			if (defs != null)
				defs.Parent = this;
			if (used_units != null)
				used_units.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (compiler_directives != null)
			{
				foreach (var child in compiler_directives)
					child?.FillParentsInAllChilds();
			}
			defs?.FillParentsInAllChilds();
			used_units?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2 + (compiler_directives == null ? 0 : compiler_directives.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return defs;
					case 1:
						return used_units;
				}
				Int32 index_counter=ind - 2;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						return compiler_directives[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						defs = (declarations)value;
						break;
					case 1:
						used_units = (uses_list)value;
						break;
				}
				Int32 index_counter=ind - 2;
				if(compiler_directives != null)
				{
					if(index_counter < compiler_directives.Count)
					{
						compiler_directives[index_counter]= (compiler_directive)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class declarations_as_statement : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public declarations_as_statement()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declarations_as_statement(declarations _defs)
		{
			this._defs=_defs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declarations_as_statement(declarations _defs,SourceContext sc)
		{
			this._defs=_defs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected declarations _defs;

		///<summary>
		///
		///</summary>
		public declarations defs
		{
			get
			{
				return _defs;
			}
			set
			{
				_defs=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			declarations_as_statement copy = new declarations_as_statement();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (defs != null)
			{
				copy.defs = (declarations)defs.Clone();
				copy.defs.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new declarations_as_statement TypedClone()
		{
			return Clone() as declarations_as_statement;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (defs != null)
				defs.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			defs?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return defs;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						defs = (declarations)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class array_size : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public array_size()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_size(expression _max_value)
		{
			this._max_value=_max_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_size(expression _max_value,SourceContext sc)
		{
			this._max_value=_max_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_size(type_definition_attr_list _attr_list,expression _max_value)
		{
			this._attr_list=_attr_list;
			this._max_value=_max_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public array_size(type_definition_attr_list _attr_list,expression _max_value,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._max_value=_max_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _max_value;

		///<summary>
		///
		///</summary>
		public expression max_value
		{
			get
			{
				return _max_value;
			}
			set
			{
				_max_value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			array_size copy = new array_size();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (max_value != null)
			{
				copy.max_value = (expression)max_value.Clone();
				copy.max_value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new array_size TypedClone()
		{
			return Clone() as array_size;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (max_value != null)
				max_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			max_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return max_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						max_value = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class enumerator : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public enumerator()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enumerator(type_definition _name,expression _value)
		{
			this._name=_name;
			this._value=_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enumerator(type_definition _name,expression _value,SourceContext sc)
		{
			this._name=_name;
			this._value=_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _name;
		protected expression _value;

		///<summary>
		///
		///</summary>
		public type_definition name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression value
		{
			get
			{
				return _value;
			}
			set
			{
				_value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			enumerator copy = new enumerator();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (name != null)
			{
				copy.name = (type_definition)name.Clone();
				copy.name.Parent = copy;
			}
			if (value != null)
			{
				copy.value = (expression)value.Clone();
				copy.value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new enumerator TypedClone()
		{
			return Clone() as enumerator;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (name != null)
				name.Parent = this;
			if (value != null)
				value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			name?.FillParentsInAllChilds();
			value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return name;
					case 1:
						return value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						name = (type_definition)value;
						break;
					case 1:
						value = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class enumerator_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public enumerator_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enumerator_list(List<enumerator> _enumerators)
		{
			this._enumerators=_enumerators;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public enumerator_list(List<enumerator> _enumerators,SourceContext sc)
		{
			this._enumerators=_enumerators;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public enumerator_list(enumerator elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<enumerator> _enumerators=new List<enumerator>();

		///<summary>
		///
		///</summary>
		public List<enumerator> enumerators
		{
			get
			{
				return _enumerators;
			}
			set
			{
				_enumerators=value;
			}
		}


		public enumerator_list Add(enumerator elem, SourceContext sc = null)
		{
			enumerators.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(enumerator el)
		{
			enumerators.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<enumerator> els)
		{
			enumerators.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params enumerator[] els)
		{
			enumerators.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(enumerator el)
		{
			var ind = enumerators.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(enumerator el, enumerator newel)
		{
			enumerators.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(enumerator el, IEnumerable<enumerator> newels)
		{
			enumerators.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(enumerator el, enumerator newel)
		{
			enumerators.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(enumerator el, IEnumerable<enumerator> newels)
		{
			enumerators.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(enumerator el)
		{
			return enumerators.Remove(el);
		}
		
		public void ReplaceInList(enumerator el, enumerator newel)
		{
			enumerators[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(enumerator el, IEnumerable<enumerator> newels)
		{
			var ind = FindIndexInList(el);
			enumerators.RemoveAt(ind);
			enumerators.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<enumerator> match)
		{
			return enumerators.RemoveAll(match);
		}
		
		public enumerator Last()
		{
			return enumerators[enumerators.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			enumerator_list copy = new enumerator_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (enumerators != null)
			{
				foreach (enumerator elem in enumerators)
				{
					if (elem != null)
					{
						copy.Add((enumerator)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new enumerator_list TypedClone()
		{
			return Clone() as enumerator_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (enumerators != null)
			{
				foreach (var child in enumerators)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (enumerators != null)
			{
				foreach (var child in enumerators)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (enumerators == null ? 0 : enumerators.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(enumerators != null)
				{
					if(index_counter < enumerators.Count)
					{
						return enumerators[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(enumerators != null)
				{
					if(index_counter < enumerators.Count)
					{
						enumerators[index_counter]= (enumerator)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class c_for_cycle : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public c_for_cycle()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_for_cycle(statement _expr1,expression _expr2,expression _expr3,statement _stmt)
		{
			this._expr1=_expr1;
			this._expr2=_expr2;
			this._expr3=_expr3;
			this._stmt=_stmt;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public c_for_cycle(statement _expr1,expression _expr2,expression _expr3,statement _stmt,SourceContext sc)
		{
			this._expr1=_expr1;
			this._expr2=_expr2;
			this._expr3=_expr3;
			this._stmt=_stmt;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected statement _expr1;
		protected expression _expr2;
		protected expression _expr3;
		protected statement _stmt;

		///<summary>
		///
		///</summary>
		public statement expr1
		{
			get
			{
				return _expr1;
			}
			set
			{
				_expr1=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression expr2
		{
			get
			{
				return _expr2;
			}
			set
			{
				_expr2=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression expr3
		{
			get
			{
				return _expr3;
			}
			set
			{
				_expr3=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement stmt
		{
			get
			{
				return _stmt;
			}
			set
			{
				_stmt=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			c_for_cycle copy = new c_for_cycle();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr1 != null)
			{
				copy.expr1 = (statement)expr1.Clone();
				copy.expr1.Parent = copy;
			}
			if (expr2 != null)
			{
				copy.expr2 = (expression)expr2.Clone();
				copy.expr2.Parent = copy;
			}
			if (expr3 != null)
			{
				copy.expr3 = (expression)expr3.Clone();
				copy.expr3.Parent = copy;
			}
			if (stmt != null)
			{
				copy.stmt = (statement)stmt.Clone();
				copy.stmt.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new c_for_cycle TypedClone()
		{
			return Clone() as c_for_cycle;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr1 != null)
				expr1.Parent = this;
			if (expr2 != null)
				expr2.Parent = this;
			if (expr3 != null)
				expr3.Parent = this;
			if (stmt != null)
				stmt.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr1?.FillParentsInAllChilds();
			expr2?.FillParentsInAllChilds();
			expr3?.FillParentsInAllChilds();
			stmt?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr1;
					case 1:
						return expr2;
					case 2:
						return expr3;
					case 3:
						return stmt;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr1 = (statement)value;
						break;
					case 1:
						expr2 = (expression)value;
						break;
					case 2:
						expr3 = (expression)value;
						break;
					case 3:
						stmt = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class switch_stmt : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public switch_stmt()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public switch_stmt(expression _condition,statement _stmt,SwitchPartType _Part)
		{
			this._condition=_condition;
			this._stmt=_stmt;
			this._Part=_Part;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public switch_stmt(expression _condition,statement _stmt,SwitchPartType _Part,SourceContext sc)
		{
			this._condition=_condition;
			this._stmt=_stmt;
			this._Part=_Part;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _condition;
		protected statement _stmt;
		protected SwitchPartType _Part;

		///<summary>
		///
		///</summary>
		public expression condition
		{
			get
			{
				return _condition;
			}
			set
			{
				_condition=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement stmt
		{
			get
			{
				return _stmt;
			}
			set
			{
				_stmt=value;
			}
		}

		///<summary>
		///
		///</summary>
		public SwitchPartType Part
		{
			get
			{
				return _Part;
			}
			set
			{
				_Part=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			switch_stmt copy = new switch_stmt();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (condition != null)
			{
				copy.condition = (expression)condition.Clone();
				copy.condition.Parent = copy;
			}
			if (stmt != null)
			{
				copy.stmt = (statement)stmt.Clone();
				copy.stmt.Parent = copy;
			}
			copy.Part = Part;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new switch_stmt TypedClone()
		{
			return Clone() as switch_stmt;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (condition != null)
				condition.Parent = this;
			if (stmt != null)
				stmt.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			condition?.FillParentsInAllChilds();
			stmt?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return condition;
					case 1:
						return stmt;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						condition = (expression)value;
						break;
					case 1:
						stmt = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class type_definition_attr_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public type_definition_attr_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition_attr_list(List<type_definition_attr> _attributes)
		{
			this._attributes=_attributes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition_attr_list(List<type_definition_attr> _attributes,SourceContext sc)
		{
			this._attributes=_attributes;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public type_definition_attr_list(type_definition_attr elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<type_definition_attr> _attributes=new List<type_definition_attr>();

		///<summary>
		///
		///</summary>
		public List<type_definition_attr> attributes
		{
			get
			{
				return _attributes;
			}
			set
			{
				_attributes=value;
			}
		}


		public type_definition_attr_list Add(type_definition_attr elem, SourceContext sc = null)
		{
			attributes.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(type_definition_attr el)
		{
			attributes.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<type_definition_attr> els)
		{
			attributes.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params type_definition_attr[] els)
		{
			attributes.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(type_definition_attr el)
		{
			var ind = attributes.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(type_definition_attr el, type_definition_attr newel)
		{
			attributes.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(type_definition_attr el, IEnumerable<type_definition_attr> newels)
		{
			attributes.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(type_definition_attr el, type_definition_attr newel)
		{
			attributes.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(type_definition_attr el, IEnumerable<type_definition_attr> newels)
		{
			attributes.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(type_definition_attr el)
		{
			return attributes.Remove(el);
		}
		
		public void ReplaceInList(type_definition_attr el, type_definition_attr newel)
		{
			attributes[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(type_definition_attr el, IEnumerable<type_definition_attr> newels)
		{
			var ind = FindIndexInList(el);
			attributes.RemoveAt(ind);
			attributes.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<type_definition_attr> match)
		{
			return attributes.RemoveAll(match);
		}
		
		public type_definition_attr Last()
		{
			return attributes[attributes.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			type_definition_attr_list copy = new type_definition_attr_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				foreach (type_definition_attr elem in attributes)
				{
					if (elem != null)
					{
						copy.Add((type_definition_attr)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new type_definition_attr_list TypedClone()
		{
			return Clone() as type_definition_attr_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
			{
				foreach (var child in attributes)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (attributes != null)
			{
				foreach (var child in attributes)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (attributes == null ? 0 : attributes.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(attributes != null)
				{
					if(index_counter < attributes.Count)
					{
						return attributes[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(attributes != null)
				{
					if(index_counter < attributes.Count)
					{
						attributes[index_counter]= (type_definition_attr)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class type_definition_attr : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public type_definition_attr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition_attr(definition_attribute _attr)
		{
			this._attr=_attr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition_attr(definition_attribute _attr,SourceContext sc)
		{
			this._attr=_attr;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition_attr(type_definition_attr_list _attr_list,definition_attribute _attr)
		{
			this._attr_list=_attr_list;
			this._attr=_attr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public type_definition_attr(type_definition_attr_list _attr_list,definition_attribute _attr,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._attr=_attr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected definition_attribute _attr;

		///<summary>
		///
		///</summary>
		public definition_attribute attr
		{
			get
			{
				return _attr;
			}
			set
			{
				_attr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			type_definition_attr copy = new type_definition_attr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			copy.attr = attr;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new type_definition_attr TypedClone()
		{
			return Clone() as type_definition_attr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class lock_stmt : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public lock_stmt()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public lock_stmt(expression _lock_object,statement _stmt)
		{
			this._lock_object=_lock_object;
			this._stmt=_stmt;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public lock_stmt(expression _lock_object,statement _stmt,SourceContext sc)
		{
			this._lock_object=_lock_object;
			this._stmt=_stmt;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _lock_object;
		protected statement _stmt;

		///<summary>
		///
		///</summary>
		public expression lock_object
		{
			get
			{
				return _lock_object;
			}
			set
			{
				_lock_object=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement stmt
		{
			get
			{
				return _stmt;
			}
			set
			{
				_stmt=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			lock_stmt copy = new lock_stmt();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (lock_object != null)
			{
				copy.lock_object = (expression)lock_object.Clone();
				copy.lock_object.Parent = copy;
			}
			if (stmt != null)
			{
				copy.stmt = (statement)stmt.Clone();
				copy.stmt.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new lock_stmt TypedClone()
		{
			return Clone() as lock_stmt;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (lock_object != null)
				lock_object.Parent = this;
			if (stmt != null)
				stmt.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			lock_object?.FillParentsInAllChilds();
			stmt?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return lock_object;
					case 1:
						return stmt;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						lock_object = (expression)value;
						break;
					case 1:
						stmt = (statement)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class compiler_directive_list : compiler_directive
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public compiler_directive_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_list(List<compiler_directive> _directives)
		{
			this._directives=_directives;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_list(List<compiler_directive> _directives,SourceContext sc)
		{
			this._directives=_directives;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_list(token_info _Name,token_info _Directive,List<compiler_directive> _directives)
		{
			this._Name=_Name;
			this._Directive=_Directive;
			this._directives=_directives;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_list(token_info _Name,token_info _Directive,List<compiler_directive> _directives,SourceContext sc)
		{
			this._Name=_Name;
			this._Directive=_Directive;
			this._directives=_directives;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public compiler_directive_list(compiler_directive elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<compiler_directive> _directives=new List<compiler_directive>();

		///<summary>
		///
		///</summary>
		public List<compiler_directive> directives
		{
			get
			{
				return _directives;
			}
			set
			{
				_directives=value;
			}
		}


		public compiler_directive_list Add(compiler_directive elem, SourceContext sc = null)
		{
			directives.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(compiler_directive el)
		{
			directives.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<compiler_directive> els)
		{
			directives.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params compiler_directive[] els)
		{
			directives.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(compiler_directive el)
		{
			var ind = directives.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(compiler_directive el, compiler_directive newel)
		{
			directives.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(compiler_directive el, IEnumerable<compiler_directive> newels)
		{
			directives.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(compiler_directive el, compiler_directive newel)
		{
			directives.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(compiler_directive el, IEnumerable<compiler_directive> newels)
		{
			directives.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(compiler_directive el)
		{
			return directives.Remove(el);
		}
		
		public void ReplaceInList(compiler_directive el, compiler_directive newel)
		{
			directives[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(compiler_directive el, IEnumerable<compiler_directive> newels)
		{
			var ind = FindIndexInList(el);
			directives.RemoveAt(ind);
			directives.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<compiler_directive> match)
		{
			return directives.RemoveAll(match);
		}
		
		public compiler_directive Last()
		{
			return directives[directives.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			compiler_directive_list copy = new compiler_directive_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (Name != null)
			{
				copy.Name = (token_info)Name.Clone();
				copy.Name.Parent = copy;
			}
			if (Directive != null)
			{
				copy.Directive = (token_info)Directive.Clone();
				copy.Directive.Parent = copy;
			}
			if (directives != null)
			{
				foreach (compiler_directive elem in directives)
				{
					if (elem != null)
					{
						copy.Add((compiler_directive)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new compiler_directive_list TypedClone()
		{
			return Clone() as compiler_directive_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (Name != null)
				Name.Parent = this;
			if (Directive != null)
				Directive.Parent = this;
			if (directives != null)
			{
				foreach (var child in directives)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			Name?.FillParentsInAllChilds();
			Directive?.FillParentsInAllChilds();
			if (directives != null)
			{
				foreach (var child in directives)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2 + (directives == null ? 0 : directives.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return Name;
					case 1:
						return Directive;
				}
				Int32 index_counter=ind - 2;
				if(directives != null)
				{
					if(index_counter < directives.Count)
					{
						return directives[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						Name = (token_info)value;
						break;
					case 1:
						Directive = (token_info)value;
						break;
				}
				Int32 index_counter=ind - 2;
				if(directives != null)
				{
					if(index_counter < directives.Count)
					{
						directives[index_counter]= (compiler_directive)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class compiler_directive_if : compiler_directive
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public compiler_directive_if()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_if(compiler_directive _if_part,compiler_directive _elseif_part)
		{
			this._if_part=_if_part;
			this._elseif_part=_elseif_part;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_if(compiler_directive _if_part,compiler_directive _elseif_part,SourceContext sc)
		{
			this._if_part=_if_part;
			this._elseif_part=_elseif_part;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_if(token_info _Name,token_info _Directive,compiler_directive _if_part,compiler_directive _elseif_part)
		{
			this._Name=_Name;
			this._Directive=_Directive;
			this._if_part=_if_part;
			this._elseif_part=_elseif_part;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public compiler_directive_if(token_info _Name,token_info _Directive,compiler_directive _if_part,compiler_directive _elseif_part,SourceContext sc)
		{
			this._Name=_Name;
			this._Directive=_Directive;
			this._if_part=_if_part;
			this._elseif_part=_elseif_part;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected compiler_directive _if_part;
		protected compiler_directive _elseif_part;

		///<summary>
		///
		///</summary>
		public compiler_directive if_part
		{
			get
			{
				return _if_part;
			}
			set
			{
				_if_part=value;
			}
		}

		///<summary>
		///
		///</summary>
		public compiler_directive elseif_part
		{
			get
			{
				return _elseif_part;
			}
			set
			{
				_elseif_part=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			compiler_directive_if copy = new compiler_directive_if();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (Name != null)
			{
				copy.Name = (token_info)Name.Clone();
				copy.Name.Parent = copy;
			}
			if (Directive != null)
			{
				copy.Directive = (token_info)Directive.Clone();
				copy.Directive.Parent = copy;
			}
			if (if_part != null)
			{
				copy.if_part = (compiler_directive)if_part.Clone();
				copy.if_part.Parent = copy;
			}
			if (elseif_part != null)
			{
				copy.elseif_part = (compiler_directive)elseif_part.Clone();
				copy.elseif_part.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new compiler_directive_if TypedClone()
		{
			return Clone() as compiler_directive_if;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (Name != null)
				Name.Parent = this;
			if (Directive != null)
				Directive.Parent = this;
			if (if_part != null)
				if_part.Parent = this;
			if (elseif_part != null)
				elseif_part.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			Name?.FillParentsInAllChilds();
			Directive?.FillParentsInAllChilds();
			if_part?.FillParentsInAllChilds();
			elseif_part?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return Name;
					case 1:
						return Directive;
					case 2:
						return if_part;
					case 3:
						return elseif_part;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						Name = (token_info)value;
						break;
					case 1:
						Directive = (token_info)value;
						break;
					case 2:
						if_part = (compiler_directive)value;
						break;
					case 3:
						elseif_part = (compiler_directive)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class documentation_comment_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public documentation_comment_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_list(List<documentation_comment_section> _sections)
		{
			this._sections=_sections;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_list(List<documentation_comment_section> _sections,SourceContext sc)
		{
			this._sections=_sections;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public documentation_comment_list(documentation_comment_section elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<documentation_comment_section> _sections=new List<documentation_comment_section>();

		///<summary>
		///
		///</summary>
		public List<documentation_comment_section> sections
		{
			get
			{
				return _sections;
			}
			set
			{
				_sections=value;
			}
		}


		public documentation_comment_list Add(documentation_comment_section elem, SourceContext sc = null)
		{
			sections.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(documentation_comment_section el)
		{
			sections.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<documentation_comment_section> els)
		{
			sections.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params documentation_comment_section[] els)
		{
			sections.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(documentation_comment_section el)
		{
			var ind = sections.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(documentation_comment_section el, documentation_comment_section newel)
		{
			sections.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(documentation_comment_section el, IEnumerable<documentation_comment_section> newels)
		{
			sections.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(documentation_comment_section el, documentation_comment_section newel)
		{
			sections.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(documentation_comment_section el, IEnumerable<documentation_comment_section> newels)
		{
			sections.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(documentation_comment_section el)
		{
			return sections.Remove(el);
		}
		
		public void ReplaceInList(documentation_comment_section el, documentation_comment_section newel)
		{
			sections[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(documentation_comment_section el, IEnumerable<documentation_comment_section> newels)
		{
			var ind = FindIndexInList(el);
			sections.RemoveAt(ind);
			sections.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<documentation_comment_section> match)
		{
			return sections.RemoveAll(match);
		}
		
		public documentation_comment_section Last()
		{
			return sections[sections.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			documentation_comment_list copy = new documentation_comment_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (sections != null)
			{
				foreach (documentation_comment_section elem in sections)
				{
					if (elem != null)
					{
						copy.Add((documentation_comment_section)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new documentation_comment_list TypedClone()
		{
			return Clone() as documentation_comment_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (sections != null)
			{
				foreach (var child in sections)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (sections != null)
			{
				foreach (var child in sections)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (sections == null ? 0 : sections.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(sections != null)
				{
					if(index_counter < sections.Count)
					{
						return sections[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(sections != null)
				{
					if(index_counter < sections.Count)
					{
						sections[index_counter]= (documentation_comment_section)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class documentation_comment_tag : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public documentation_comment_tag()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_tag(string _name,List<documentation_comment_tag_param> _parameters,string _text)
		{
			this._name=_name;
			this._parameters=_parameters;
			this._text=_text;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_tag(string _name,List<documentation_comment_tag_param> _parameters,string _text,SourceContext sc)
		{
			this._name=_name;
			this._parameters=_parameters;
			this._text=_text;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public documentation_comment_tag(documentation_comment_tag_param elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected string _name;
		protected List<documentation_comment_tag_param> _parameters=new List<documentation_comment_tag_param>();
		protected string _text;

		///<summary>
		///
		///</summary>
		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public List<documentation_comment_tag_param> parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters=value;
			}
		}

		///<summary>
		///
		///</summary>
		public string text
		{
			get
			{
				return _text;
			}
			set
			{
				_text=value;
			}
		}


		public documentation_comment_tag Add(documentation_comment_tag_param elem, SourceContext sc = null)
		{
			parameters.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(documentation_comment_tag_param el)
		{
			parameters.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<documentation_comment_tag_param> els)
		{
			parameters.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params documentation_comment_tag_param[] els)
		{
			parameters.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(documentation_comment_tag_param el)
		{
			var ind = parameters.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(documentation_comment_tag_param el, documentation_comment_tag_param newel)
		{
			parameters.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(documentation_comment_tag_param el, IEnumerable<documentation_comment_tag_param> newels)
		{
			parameters.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(documentation_comment_tag_param el, documentation_comment_tag_param newel)
		{
			parameters.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(documentation_comment_tag_param el, IEnumerable<documentation_comment_tag_param> newels)
		{
			parameters.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(documentation_comment_tag_param el)
		{
			return parameters.Remove(el);
		}
		
		public void ReplaceInList(documentation_comment_tag_param el, documentation_comment_tag_param newel)
		{
			parameters[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(documentation_comment_tag_param el, IEnumerable<documentation_comment_tag_param> newels)
		{
			var ind = FindIndexInList(el);
			parameters.RemoveAt(ind);
			parameters.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<documentation_comment_tag_param> match)
		{
			return parameters.RemoveAll(match);
		}
		
		public documentation_comment_tag_param Last()
		{
			return parameters[parameters.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			documentation_comment_tag copy = new documentation_comment_tag();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.name = name;
			if (parameters != null)
			{
				foreach (documentation_comment_tag_param elem in parameters)
				{
					if (elem != null)
					{
						copy.Add((documentation_comment_tag_param)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.text = text;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new documentation_comment_tag TypedClone()
		{
			return Clone() as documentation_comment_tag;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (parameters != null)
			{
				foreach (var child in parameters)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (parameters != null)
			{
				foreach (var child in parameters)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (parameters == null ? 0 : parameters.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(parameters != null)
				{
					if(index_counter < parameters.Count)
					{
						return parameters[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(parameters != null)
				{
					if(index_counter < parameters.Count)
					{
						parameters[index_counter]= (documentation_comment_tag_param)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class documentation_comment_tag_param : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public documentation_comment_tag_param()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_tag_param(string _name,string _value)
		{
			this._name=_name;
			this._value=_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_tag_param(string _name,string _value,SourceContext sc)
		{
			this._name=_name;
			this._value=_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected string _name;
		protected string _value;

		///<summary>
		///
		///</summary>
		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public string value
		{
			get
			{
				return _value;
			}
			set
			{
				_value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			documentation_comment_tag_param copy = new documentation_comment_tag_param();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.name = name;
			copy.value = value;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new documentation_comment_tag_param TypedClone()
		{
			return Clone() as documentation_comment_tag_param;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class documentation_comment_section : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public documentation_comment_section()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_section(List<documentation_comment_tag> _tags,string _text)
		{
			this._tags=_tags;
			this._text=_text;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public documentation_comment_section(List<documentation_comment_tag> _tags,string _text,SourceContext sc)
		{
			this._tags=_tags;
			this._text=_text;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public documentation_comment_section(documentation_comment_tag elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<documentation_comment_tag> _tags=new List<documentation_comment_tag>();
		protected string _text;

		///<summary>
		///
		///</summary>
		public List<documentation_comment_tag> tags
		{
			get
			{
				return _tags;
			}
			set
			{
				_tags=value;
			}
		}

		///<summary>
		///
		///</summary>
		public string text
		{
			get
			{
				return _text;
			}
			set
			{
				_text=value;
			}
		}


		public documentation_comment_section Add(documentation_comment_tag elem, SourceContext sc = null)
		{
			tags.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(documentation_comment_tag el)
		{
			tags.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<documentation_comment_tag> els)
		{
			tags.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params documentation_comment_tag[] els)
		{
			tags.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(documentation_comment_tag el)
		{
			var ind = tags.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(documentation_comment_tag el, documentation_comment_tag newel)
		{
			tags.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(documentation_comment_tag el, IEnumerable<documentation_comment_tag> newels)
		{
			tags.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(documentation_comment_tag el, documentation_comment_tag newel)
		{
			tags.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(documentation_comment_tag el, IEnumerable<documentation_comment_tag> newels)
		{
			tags.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(documentation_comment_tag el)
		{
			return tags.Remove(el);
		}
		
		public void ReplaceInList(documentation_comment_tag el, documentation_comment_tag newel)
		{
			tags[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(documentation_comment_tag el, IEnumerable<documentation_comment_tag> newels)
		{
			var ind = FindIndexInList(el);
			tags.RemoveAt(ind);
			tags.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<documentation_comment_tag> match)
		{
			return tags.RemoveAll(match);
		}
		
		public documentation_comment_tag Last()
		{
			return tags[tags.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			documentation_comment_section copy = new documentation_comment_section();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (tags != null)
			{
				foreach (documentation_comment_tag elem in tags)
				{
					if (elem != null)
					{
						copy.Add((documentation_comment_tag)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.text = text;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new documentation_comment_section TypedClone()
		{
			return Clone() as documentation_comment_section;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (tags != null)
			{
				foreach (var child in tags)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (tags != null)
			{
				foreach (var child in tags)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (tags == null ? 0 : tags.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(tags != null)
				{
					if(index_counter < tags.Count)
					{
						return tags[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(tags != null)
				{
					if(index_counter < tags.Count)
					{
						tags[index_counter]= (documentation_comment_tag)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class token_taginfo : token_info
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public token_taginfo()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public token_taginfo(object _tag)
		{
			this._tag=_tag;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public token_taginfo(object _tag,SourceContext sc)
		{
			this._tag=_tag;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public token_taginfo(string _text,object _tag)
		{
			this._text=_text;
			this._tag=_tag;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public token_taginfo(string _text,object _tag,SourceContext sc)
		{
			this._text=_text;
			this._tag=_tag;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected object _tag;

		///<summary>
		///
		///</summary>
		public object tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			token_taginfo copy = new token_taginfo();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			copy.text = text;
			copy.tag = tag;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new token_taginfo TypedClone()
		{
			return Clone() as token_taginfo;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class declaration_specificator : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public declaration_specificator()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declaration_specificator(DeclarationSpecificator _specificator,string _name)
		{
			this._specificator=_specificator;
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declaration_specificator(DeclarationSpecificator _specificator,string _name,SourceContext sc)
		{
			this._specificator=_specificator;
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declaration_specificator(type_definition_attr_list _attr_list,DeclarationSpecificator _specificator,string _name)
		{
			this._attr_list=_attr_list;
			this._specificator=_specificator;
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public declaration_specificator(type_definition_attr_list _attr_list,DeclarationSpecificator _specificator,string _name,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._specificator=_specificator;
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected DeclarationSpecificator _specificator;
		protected string _name;

		///<summary>
		///
		///</summary>
		public DeclarationSpecificator specificator
		{
			get
			{
				return _specificator;
			}
			set
			{
				_specificator=value;
			}
		}

		///<summary>
		///
		///</summary>
		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			declaration_specificator copy = new declaration_specificator();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			copy.specificator = specificator;
			copy.name = name;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new declaration_specificator TypedClone()
		{
			return Clone() as declaration_specificator;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class ident_with_templateparams : addressed_value_funcname
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public ident_with_templateparams()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ident_with_templateparams(addressed_value _name,template_param_list _template_params)
		{
			this._name=_name;
			this._template_params=_template_params;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public ident_with_templateparams(addressed_value _name,template_param_list _template_params,SourceContext sc)
		{
			this._name=_name;
			this._template_params=_template_params;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _name;
		protected template_param_list _template_params;

		///<summary>
		///
		///</summary>
		public addressed_value name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public template_param_list template_params
		{
			get
			{
				return _template_params;
			}
			set
			{
				_template_params=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			ident_with_templateparams copy = new ident_with_templateparams();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (name != null)
			{
				copy.name = (addressed_value)name.Clone();
				copy.name.Parent = copy;
			}
			if (template_params != null)
			{
				copy.template_params = (template_param_list)template_params.Clone();
				copy.template_params.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new ident_with_templateparams TypedClone()
		{
			return Clone() as ident_with_templateparams;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (name != null)
				name.Parent = this;
			if (template_params != null)
				template_params.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			name?.FillParentsInAllChilds();
			template_params?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return name;
					case 1:
						return template_params;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						name = (addressed_value)value;
						break;
					case 1:
						template_params = (template_param_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class template_type_name : ident
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public template_type_name()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_name(ident_list _template_args)
		{
			this._template_args=_template_args;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_name(ident_list _template_args,SourceContext sc)
		{
			this._template_args=_template_args;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_name(string _name,ident_list _template_args)
		{
			this._name=_name;
			this._template_args=_template_args;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_type_name(string _name,ident_list _template_args,SourceContext sc)
		{
			this._name=_name;
			this._template_args=_template_args;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident_list _template_args;

		///<summary>
		///
		///</summary>
		public ident_list template_args
		{
			get
			{
				return _template_args;
			}
			set
			{
				_template_args=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			template_type_name copy = new template_type_name();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			if (template_args != null)
			{
				copy.template_args = (ident_list)template_args.Clone();
				copy.template_args.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new template_type_name TypedClone()
		{
			return Clone() as template_type_name;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (template_args != null)
				template_args.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			template_args?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return template_args;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						template_args = (ident_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class default_operator : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public default_operator()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public default_operator(named_type_reference _type_name)
		{
			this._type_name=_type_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public default_operator(named_type_reference _type_name,SourceContext sc)
		{
			this._type_name=_type_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected named_type_reference _type_name;

		///<summary>
		///
		///</summary>
		public named_type_reference type_name
		{
			get
			{
				return _type_name;
			}
			set
			{
				_type_name=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			default_operator copy = new default_operator();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (type_name != null)
			{
				copy.type_name = (named_type_reference)type_name.Clone();
				copy.type_name.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new default_operator TypedClone()
		{
			return Clone() as default_operator;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (type_name != null)
				type_name.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			type_name?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return type_name;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						type_name = (named_type_reference)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class bracket_expr : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public bracket_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public bracket_expr(expression _expr)
		{
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public bracket_expr(expression _expr,SourceContext sc)
		{
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _expr;

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			bracket_expr copy = new bracket_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new bracket_expr TypedClone()
		{
			return Clone() as bracket_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class attribute : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public attribute()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public attribute(ident _qualifier,named_type_reference _type,expression_list _arguments)
		{
			this._qualifier=_qualifier;
			this._type=_type;
			this._arguments=_arguments;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public attribute(ident _qualifier,named_type_reference _type,expression_list _arguments,SourceContext sc)
		{
			this._qualifier=_qualifier;
			this._type=_type;
			this._arguments=_arguments;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _qualifier;
		protected named_type_reference _type;
		protected expression_list _arguments;

		///<summary>
		///
		///</summary>
		public ident qualifier
		{
			get
			{
				return _qualifier;
			}
			set
			{
				_qualifier=value;
			}
		}

		///<summary>
		///
		///</summary>
		public named_type_reference type
		{
			get
			{
				return _type;
			}
			set
			{
				_type=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression_list arguments
		{
			get
			{
				return _arguments;
			}
			set
			{
				_arguments=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			attribute copy = new attribute();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (qualifier != null)
			{
				copy.qualifier = (ident)qualifier.Clone();
				copy.qualifier.Parent = copy;
			}
			if (type != null)
			{
				copy.type = (named_type_reference)type.Clone();
				copy.type.Parent = copy;
			}
			if (arguments != null)
			{
				copy.arguments = (expression_list)arguments.Clone();
				copy.arguments.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new attribute TypedClone()
		{
			return Clone() as attribute;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (qualifier != null)
				qualifier.Parent = this;
			if (type != null)
				type.Parent = this;
			if (arguments != null)
				arguments.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			qualifier?.FillParentsInAllChilds();
			type?.FillParentsInAllChilds();
			arguments?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return qualifier;
					case 1:
						return type;
					case 2:
						return arguments;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						qualifier = (ident)value;
						break;
					case 1:
						type = (named_type_reference)value;
						break;
					case 2:
						arguments = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class simple_attribute_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public simple_attribute_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public simple_attribute_list(List<attribute> _attributes)
		{
			this._attributes=_attributes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public simple_attribute_list(List<attribute> _attributes,SourceContext sc)
		{
			this._attributes=_attributes;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public simple_attribute_list(attribute elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<attribute> _attributes=new List<attribute>();

		///<summary>
		///
		///</summary>
		public List<attribute> attributes
		{
			get
			{
				return _attributes;
			}
			set
			{
				_attributes=value;
			}
		}


		public simple_attribute_list Add(attribute elem, SourceContext sc = null)
		{
			attributes.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(attribute el)
		{
			attributes.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<attribute> els)
		{
			attributes.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params attribute[] els)
		{
			attributes.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(attribute el)
		{
			var ind = attributes.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(attribute el, attribute newel)
		{
			attributes.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(attribute el, IEnumerable<attribute> newels)
		{
			attributes.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(attribute el, attribute newel)
		{
			attributes.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(attribute el, IEnumerable<attribute> newels)
		{
			attributes.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(attribute el)
		{
			return attributes.Remove(el);
		}
		
		public void ReplaceInList(attribute el, attribute newel)
		{
			attributes[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(attribute el, IEnumerable<attribute> newels)
		{
			var ind = FindIndexInList(el);
			attributes.RemoveAt(ind);
			attributes.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<attribute> match)
		{
			return attributes.RemoveAll(match);
		}
		
		public attribute Last()
		{
			return attributes[attributes.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			simple_attribute_list copy = new simple_attribute_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				foreach (attribute elem in attributes)
				{
					if (elem != null)
					{
						copy.Add((attribute)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new simple_attribute_list TypedClone()
		{
			return Clone() as simple_attribute_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
			{
				foreach (var child in attributes)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (attributes != null)
			{
				foreach (var child in attributes)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (attributes == null ? 0 : attributes.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(attributes != null)
				{
					if(index_counter < attributes.Count)
					{
						return attributes[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(attributes != null)
				{
					if(index_counter < attributes.Count)
					{
						attributes[index_counter]= (attribute)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class attribute_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public attribute_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public attribute_list(List<simple_attribute_list> _attributes)
		{
			this._attributes=_attributes;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public attribute_list(List<simple_attribute_list> _attributes,SourceContext sc)
		{
			this._attributes=_attributes;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public attribute_list(simple_attribute_list elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<simple_attribute_list> _attributes=new List<simple_attribute_list>();

		///<summary>
		///
		///</summary>
		public List<simple_attribute_list> attributes
		{
			get
			{
				return _attributes;
			}
			set
			{
				_attributes=value;
			}
		}


		public attribute_list Add(simple_attribute_list elem, SourceContext sc = null)
		{
			attributes.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(simple_attribute_list el)
		{
			attributes.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<simple_attribute_list> els)
		{
			attributes.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params simple_attribute_list[] els)
		{
			attributes.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(simple_attribute_list el)
		{
			var ind = attributes.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(simple_attribute_list el, simple_attribute_list newel)
		{
			attributes.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(simple_attribute_list el, IEnumerable<simple_attribute_list> newels)
		{
			attributes.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(simple_attribute_list el, simple_attribute_list newel)
		{
			attributes.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(simple_attribute_list el, IEnumerable<simple_attribute_list> newels)
		{
			attributes.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(simple_attribute_list el)
		{
			return attributes.Remove(el);
		}
		
		public void ReplaceInList(simple_attribute_list el, simple_attribute_list newel)
		{
			attributes[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(simple_attribute_list el, IEnumerable<simple_attribute_list> newels)
		{
			var ind = FindIndexInList(el);
			attributes.RemoveAt(ind);
			attributes.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<simple_attribute_list> match)
		{
			return attributes.RemoveAll(match);
		}
		
		public simple_attribute_list Last()
		{
			return attributes[attributes.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			attribute_list copy = new attribute_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				foreach (simple_attribute_list elem in attributes)
				{
					if (elem != null)
					{
						copy.Add((simple_attribute_list)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new attribute_list TypedClone()
		{
			return Clone() as attribute_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
			{
				foreach (var child in attributes)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (attributes != null)
			{
				foreach (var child in attributes)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (attributes == null ? 0 : attributes.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(attributes != null)
				{
					if(index_counter < attributes.Count)
					{
						return attributes[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(attributes != null)
				{
					if(index_counter < attributes.Count)
					{
						attributes[index_counter]= (simple_attribute_list)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class function_lambda_definition : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public function_lambda_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_lambda_definition(ident_list _ident_list,type_definition _return_type,formal_parameters _formal_parameters,statement _proc_body,procedure_definition _proc_definition,expression_list _parameters,string _lambda_name,List<declaration> _defs,LambdaVisitMode _lambda_visit_mode,syntax_tree_node _substituting_node,int _usedkeyword)
		{
			this._ident_list=_ident_list;
			this._return_type=_return_type;
			this._formal_parameters=_formal_parameters;
			this._proc_body=_proc_body;
			this._proc_definition=_proc_definition;
			this._parameters=_parameters;
			this._lambda_name=_lambda_name;
			this._defs=_defs;
			this._lambda_visit_mode=_lambda_visit_mode;
			this._substituting_node=_substituting_node;
			this._usedkeyword=_usedkeyword;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_lambda_definition(ident_list _ident_list,type_definition _return_type,formal_parameters _formal_parameters,statement _proc_body,procedure_definition _proc_definition,expression_list _parameters,string _lambda_name,List<declaration> _defs,LambdaVisitMode _lambda_visit_mode,syntax_tree_node _substituting_node,int _usedkeyword,SourceContext sc)
		{
			this._ident_list=_ident_list;
			this._return_type=_return_type;
			this._formal_parameters=_formal_parameters;
			this._proc_body=_proc_body;
			this._proc_definition=_proc_definition;
			this._parameters=_parameters;
			this._lambda_name=_lambda_name;
			this._defs=_defs;
			this._lambda_visit_mode=_lambda_visit_mode;
			this._substituting_node=_substituting_node;
			this._usedkeyword=_usedkeyword;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public function_lambda_definition(declaration elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected ident_list _ident_list;
		protected type_definition _return_type;
		protected formal_parameters _formal_parameters;
		protected statement _proc_body;
		protected procedure_definition _proc_definition;
		protected expression_list _parameters;
		protected string _lambda_name;
		protected List<declaration> _defs;
		protected LambdaVisitMode _lambda_visit_mode;
		protected syntax_tree_node _substituting_node;
		protected int _usedkeyword;

		///<summary>
		///
		///</summary>
		public ident_list ident_list
		{
			get
			{
				return _ident_list;
			}
			set
			{
				_ident_list=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition return_type
		{
			get
			{
				return _return_type;
			}
			set
			{
				_return_type=value;
			}
		}

		///<summary>
		///
		///</summary>
		public formal_parameters formal_parameters
		{
			get
			{
				return _formal_parameters;
			}
			set
			{
				_formal_parameters=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement proc_body
		{
			get
			{
				return _proc_body;
			}
			set
			{
				_proc_body=value;
			}
		}

		///<summary>
		///
		///</summary>
		public procedure_definition proc_definition
		{
			get
			{
				return _proc_definition;
			}
			set
			{
				_proc_definition=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression_list parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters=value;
			}
		}

		///<summary>
		///
		///</summary>
		public string lambda_name
		{
			get
			{
				return _lambda_name;
			}
			set
			{
				_lambda_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public List<declaration> defs
		{
			get
			{
				return _defs;
			}
			set
			{
				_defs=value;
			}
		}

		///<summary>
		///
		///</summary>
		public LambdaVisitMode lambda_visit_mode
		{
			get
			{
				return _lambda_visit_mode;
			}
			set
			{
				_lambda_visit_mode=value;
			}
		}

		///<summary>
		///
		///</summary>
		public syntax_tree_node substituting_node
		{
			get
			{
				return _substituting_node;
			}
			set
			{
				_substituting_node=value;
			}
		}

		///<summary>
		///
		///</summary>
		public int usedkeyword
		{
			get
			{
				return _usedkeyword;
			}
			set
			{
				_usedkeyword=value;
			}
		}


		public function_lambda_definition Add(declaration elem, SourceContext sc = null)
		{
			defs.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(declaration el)
		{
			defs.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<declaration> els)
		{
			defs.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params declaration[] els)
		{
			defs.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(declaration el)
		{
			var ind = defs.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(declaration el, declaration newel)
		{
			defs.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(declaration el, IEnumerable<declaration> newels)
		{
			defs.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(declaration el, declaration newel)
		{
			defs.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(declaration el, IEnumerable<declaration> newels)
		{
			defs.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(declaration el)
		{
			return defs.Remove(el);
		}
		
		public void ReplaceInList(declaration el, declaration newel)
		{
			defs[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(declaration el, IEnumerable<declaration> newels)
		{
			var ind = FindIndexInList(el);
			defs.RemoveAt(ind);
			defs.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<declaration> match)
		{
			return defs.RemoveAll(match);
		}
		
		public declaration Last()
		{
			return defs[defs.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			function_lambda_definition copy = new function_lambda_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (ident_list != null)
			{
				copy.ident_list = (ident_list)ident_list.Clone();
				copy.ident_list.Parent = copy;
			}
			if (return_type != null)
			{
				copy.return_type = (type_definition)return_type.Clone();
				copy.return_type.Parent = copy;
			}
			if (formal_parameters != null)
			{
				copy.formal_parameters = (formal_parameters)formal_parameters.Clone();
				copy.formal_parameters.Parent = copy;
			}
			if (proc_body != null)
			{
				copy.proc_body = (statement)proc_body.Clone();
				copy.proc_body.Parent = copy;
			}
			if (proc_definition != null)
			{
				copy.proc_definition = (procedure_definition)proc_definition.Clone();
				copy.proc_definition.Parent = copy;
			}
			if (parameters != null)
			{
				copy.parameters = (expression_list)parameters.Clone();
				copy.parameters.Parent = copy;
			}
			copy.lambda_name = lambda_name;
			if (defs != null)
			{
				foreach (declaration elem in defs)
				{
					if (elem != null)
					{
						copy.Add((declaration)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.lambda_visit_mode = lambda_visit_mode;
			if (substituting_node != null)
			{
				copy.substituting_node = substituting_node.Clone();
				copy.substituting_node.Parent = copy;
			}
			copy.usedkeyword = usedkeyword;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new function_lambda_definition TypedClone()
		{
			return Clone() as function_lambda_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (ident_list != null)
				ident_list.Parent = this;
			if (return_type != null)
				return_type.Parent = this;
			if (formal_parameters != null)
				formal_parameters.Parent = this;
			if (proc_body != null)
				proc_body.Parent = this;
			if (proc_definition != null)
				proc_definition.Parent = this;
			if (parameters != null)
				parameters.Parent = this;
			if (defs != null)
			{
				foreach (var child in defs)
					if (child != null)
						child.Parent = this;
			}
			if (substituting_node != null)
				substituting_node.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			ident_list?.FillParentsInAllChilds();
			return_type?.FillParentsInAllChilds();
			formal_parameters?.FillParentsInAllChilds();
			proc_body?.FillParentsInAllChilds();
			proc_definition?.FillParentsInAllChilds();
			parameters?.FillParentsInAllChilds();
			if (defs != null)
			{
				foreach (var child in defs)
					child?.FillParentsInAllChilds();
			}
			substituting_node?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 7;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 7 + (defs == null ? 0 : defs.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return ident_list;
					case 1:
						return return_type;
					case 2:
						return formal_parameters;
					case 3:
						return proc_body;
					case 4:
						return proc_definition;
					case 5:
						return parameters;
					case 6:
						return substituting_node;
				}
				Int32 index_counter=ind - 7;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						return defs[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						ident_list = (ident_list)value;
						break;
					case 1:
						return_type = (type_definition)value;
						break;
					case 2:
						formal_parameters = (formal_parameters)value;
						break;
					case 3:
						proc_body = (statement)value;
						break;
					case 4:
						proc_definition = (procedure_definition)value;
						break;
					case 5:
						parameters = (expression_list)value;
						break;
					case 6:
						substituting_node = (syntax_tree_node)value;
						break;
				}
				Int32 index_counter=ind - 7;
				if(defs != null)
				{
					if(index_counter < defs.Count)
					{
						defs[index_counter]= (declaration)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class function_lambda_call : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public function_lambda_call()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_lambda_call(function_lambda_definition _f_lambda_def,expression_list _parameters)
		{
			this._f_lambda_def=_f_lambda_def;
			this._parameters=_parameters;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public function_lambda_call(function_lambda_definition _f_lambda_def,expression_list _parameters,SourceContext sc)
		{
			this._f_lambda_def=_f_lambda_def;
			this._parameters=_parameters;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected function_lambda_definition _f_lambda_def;
		protected expression_list _parameters;

		///<summary>
		///
		///</summary>
		public function_lambda_definition f_lambda_def
		{
			get
			{
				return _f_lambda_def;
			}
			set
			{
				_f_lambda_def=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression_list parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			function_lambda_call copy = new function_lambda_call();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (f_lambda_def != null)
			{
				copy.f_lambda_def = (function_lambda_definition)f_lambda_def.Clone();
				copy.f_lambda_def.Parent = copy;
			}
			if (parameters != null)
			{
				copy.parameters = (expression_list)parameters.Clone();
				copy.parameters.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new function_lambda_call TypedClone()
		{
			return Clone() as function_lambda_call;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (f_lambda_def != null)
				f_lambda_def.Parent = this;
			if (parameters != null)
				parameters.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			f_lambda_def?.FillParentsInAllChilds();
			parameters?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return f_lambda_def;
					case 1:
						return parameters;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						f_lambda_def = (function_lambda_definition)value;
						break;
					case 1:
						parameters = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Узел для семантических проверок на этапе построения семантического дерева. Сделан для узлов синтаксического дерева, реализующих синтаксический сахар. Может, видимо, использоваться и для обычных семантических проверок
	///</summary>
	[Serializable]
	public partial class semantic_check : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public semantic_check()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_check(string _CheckName,List<syntax_tree_node> _param,int _fictive)
		{
			this._CheckName=_CheckName;
			this._param=_param;
			this._fictive=_fictive;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_check(string _CheckName,List<syntax_tree_node> _param,int _fictive,SourceContext sc)
		{
			this._CheckName=_CheckName;
			this._param=_param;
			this._fictive=_fictive;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public semantic_check(syntax_tree_node elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected string _CheckName;
		protected List<syntax_tree_node> _param=new List<syntax_tree_node>();
		protected int _fictive;

		///<summary>
		///Тип проверки. Пока строковый. Например, является ли выражение целым
		///</summary>
		public string CheckName
		{
			get
			{
				return _CheckName;
			}
			set
			{
				_CheckName=value;
			}
		}

		///<summary>
		///Параметры - синтаксические узлы для проверки
		///</summary>
		public List<syntax_tree_node> param
		{
			get
			{
				return _param;
			}
			set
			{
				_param=value;
			}
		}

		///<summary>
		///Фиктивное поле - чтобы можно было вручную написать конструктор с params
		///</summary>
		public int fictive
		{
			get
			{
				return _fictive;
			}
			set
			{
				_fictive=value;
			}
		}


		public semantic_check Add(syntax_tree_node elem, SourceContext sc = null)
		{
			param.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(syntax_tree_node el)
		{
			param.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<syntax_tree_node> els)
		{
			param.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params syntax_tree_node[] els)
		{
			param.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(syntax_tree_node el)
		{
			var ind = param.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(syntax_tree_node el, syntax_tree_node newel)
		{
			param.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(syntax_tree_node el, IEnumerable<syntax_tree_node> newels)
		{
			param.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(syntax_tree_node el, syntax_tree_node newel)
		{
			param.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(syntax_tree_node el, IEnumerable<syntax_tree_node> newels)
		{
			param.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(syntax_tree_node el)
		{
			return param.Remove(el);
		}
		
		public void ReplaceInList(syntax_tree_node el, syntax_tree_node newel)
		{
			param[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(syntax_tree_node el, IEnumerable<syntax_tree_node> newels)
		{
			var ind = FindIndexInList(el);
			param.RemoveAt(ind);
			param.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<syntax_tree_node> match)
		{
			return param.RemoveAll(match);
		}
		
		public syntax_tree_node Last()
		{
			return param[param.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			semantic_check copy = new semantic_check();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.CheckName = CheckName;
			if (param != null)
			{
				foreach (syntax_tree_node elem in param)
				{
					if (elem != null)
					{
						copy.Add(elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			copy.fictive = fictive;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new semantic_check TypedClone()
		{
			return Clone() as semantic_check;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (param != null)
			{
				foreach (var child in param)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (param != null)
			{
				foreach (var child in param)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (param == null ? 0 : param.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(param != null)
				{
					if(index_counter < param.Count)
					{
						return param[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(param != null)
				{
					if(index_counter < param.Count)
					{
						param[index_counter]= (syntax_tree_node)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class lambda_inferred_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public lambda_inferred_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public lambda_inferred_type(object _real_type)
		{
			this._real_type=_real_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public lambda_inferred_type(object _real_type,SourceContext sc)
		{
			this._real_type=_real_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public lambda_inferred_type(type_definition_attr_list _attr_list,object _real_type)
		{
			this._attr_list=_attr_list;
			this._real_type=_real_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public lambda_inferred_type(type_definition_attr_list _attr_list,object _real_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._real_type=_real_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected object _real_type;

		///<summary>
		///
		///</summary>
		public object real_type
		{
			get
			{
				return _real_type;
			}
			set
			{
				_real_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			lambda_inferred_type copy = new lambda_inferred_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			copy.real_type = real_type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new lambda_inferred_type TypedClone()
		{
			return Clone() as lambda_inferred_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class same_type_node : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public same_type_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public same_type_node(expression _ex)
		{
			this._ex=_ex;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public same_type_node(expression _ex,SourceContext sc)
		{
			this._ex=_ex;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public same_type_node(type_definition_attr_list _attr_list,expression _ex)
		{
			this._attr_list=_attr_list;
			this._ex=_ex;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public same_type_node(type_definition_attr_list _attr_list,expression _ex,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._ex=_ex;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _ex;

		///<summary>
		///
		///</summary>
		public expression ex
		{
			get
			{
				return _ex;
			}
			set
			{
				_ex=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			same_type_node copy = new same_type_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (ex != null)
			{
				copy.ex = (expression)ex.Clone();
				copy.ex.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new same_type_node TypedClone()
		{
			return Clone() as same_type_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (ex != null)
				ex.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			ex?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return ex;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						ex = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class name_assign_expr : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public name_assign_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public name_assign_expr(ident _name,expression _expr)
		{
			this._name=_name;
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public name_assign_expr(ident _name,expression _expr,SourceContext sc)
		{
			this._name=_name;
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected ident _name;
		protected expression _expr;

		///<summary>
		///
		///</summary>
		public ident name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			name_assign_expr copy = new name_assign_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (name != null)
			{
				copy.name = (ident)name.Clone();
				copy.name.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new name_assign_expr TypedClone()
		{
			return Clone() as name_assign_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (name != null)
				name.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			name?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return name;
					case 1:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						name = (ident)value;
						break;
					case 1:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class name_assign_expr_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public name_assign_expr_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public name_assign_expr_list(List<name_assign_expr> _name_expr)
		{
			this._name_expr=_name_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public name_assign_expr_list(List<name_assign_expr> _name_expr,SourceContext sc)
		{
			this._name_expr=_name_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public name_assign_expr_list(name_assign_expr elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<name_assign_expr> _name_expr=new List<name_assign_expr>();

		///<summary>
		///
		///</summary>
		public List<name_assign_expr> name_expr
		{
			get
			{
				return _name_expr;
			}
			set
			{
				_name_expr=value;
			}
		}


		public name_assign_expr_list Add(name_assign_expr elem, SourceContext sc = null)
		{
			name_expr.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(name_assign_expr el)
		{
			name_expr.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<name_assign_expr> els)
		{
			name_expr.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params name_assign_expr[] els)
		{
			name_expr.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(name_assign_expr el)
		{
			var ind = name_expr.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(name_assign_expr el, name_assign_expr newel)
		{
			name_expr.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(name_assign_expr el, IEnumerable<name_assign_expr> newels)
		{
			name_expr.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(name_assign_expr el, name_assign_expr newel)
		{
			name_expr.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(name_assign_expr el, IEnumerable<name_assign_expr> newels)
		{
			name_expr.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(name_assign_expr el)
		{
			return name_expr.Remove(el);
		}
		
		public void ReplaceInList(name_assign_expr el, name_assign_expr newel)
		{
			name_expr[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(name_assign_expr el, IEnumerable<name_assign_expr> newels)
		{
			var ind = FindIndexInList(el);
			name_expr.RemoveAt(ind);
			name_expr.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<name_assign_expr> match)
		{
			return name_expr.RemoveAll(match);
		}
		
		public name_assign_expr Last()
		{
			return name_expr[name_expr.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			name_assign_expr_list copy = new name_assign_expr_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (name_expr != null)
			{
				foreach (name_assign_expr elem in name_expr)
				{
					if (elem != null)
					{
						copy.Add((name_assign_expr)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new name_assign_expr_list TypedClone()
		{
			return Clone() as name_assign_expr_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (name_expr != null)
			{
				foreach (var child in name_expr)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (name_expr != null)
			{
				foreach (var child in name_expr)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (name_expr == null ? 0 : name_expr.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(name_expr != null)
				{
					if(index_counter < name_expr.Count)
					{
						return name_expr[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(name_expr != null)
				{
					if(index_counter < name_expr.Count)
					{
						name_expr[index_counter]= (name_assign_expr)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Это - сахарная конструкция.
/// Объект безымянного класса. Например: new class(Name := 'Иванов'; Age := 25);
/// ne - это узел для генерации кода, основной узел предназначен для форматирования
	///</summary>
	[Serializable]
	public partial class unnamed_type_object : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public unnamed_type_object()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unnamed_type_object(name_assign_expr_list _ne_list,bool _is_class,new_expr _new_ex)
		{
			this._ne_list=_ne_list;
			this._is_class=_is_class;
			this._new_ex=_new_ex;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public unnamed_type_object(name_assign_expr_list _ne_list,bool _is_class,new_expr _new_ex,SourceContext sc)
		{
			this._ne_list=_ne_list;
			this._is_class=_is_class;
			this._new_ex=_new_ex;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected name_assign_expr_list _ne_list;
		protected bool _is_class;
		protected new_expr _new_ex;

		///<summary>
		///
		///</summary>
		public name_assign_expr_list ne_list
		{
			get
			{
				return _ne_list;
			}
			set
			{
				_ne_list=value;
			}
		}

		///<summary>
		///
		///</summary>
		public bool is_class
		{
			get
			{
				return _is_class;
			}
			set
			{
				_is_class=value;
			}
		}

		///<summary>
		///
		///</summary>
		public new_expr new_ex
		{
			get
			{
				return _new_ex;
			}
			set
			{
				_new_ex=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			unnamed_type_object copy = new unnamed_type_object();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (ne_list != null)
			{
				copy.ne_list = (name_assign_expr_list)ne_list.Clone();
				copy.ne_list.Parent = copy;
			}
			copy.is_class = is_class;
			if (new_ex != null)
			{
				copy.new_ex = (new_expr)new_ex.Clone();
				copy.new_ex.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new unnamed_type_object TypedClone()
		{
			return Clone() as unnamed_type_object;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (ne_list != null)
				ne_list.Parent = this;
			if (new_ex != null)
				new_ex.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			ne_list?.FillParentsInAllChilds();
			new_ex?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return ne_list;
					case 1:
						return new_ex;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						ne_list = (name_assign_expr_list)value;
						break;
					case 1:
						new_ex = (new_expr)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class semantic_type_node : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public semantic_type_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_type_node(Object _type)
		{
			this._type=_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_type_node(Object _type,SourceContext sc)
		{
			this._type=_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_type_node(type_definition_attr_list _attr_list,Object _type)
		{
			this._attr_list=_attr_list;
			this._type=_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_type_node(type_definition_attr_list _attr_list,Object _type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._type=_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected Object _type;

		///<summary>
		///
		///</summary>
		public Object type
		{
			get
			{
				return _type;
			}
			set
			{
				_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			semantic_type_node copy = new semantic_type_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			copy.type = type;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new semantic_type_node TypedClone()
		{
			return Clone() as semantic_type_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class short_func_definition : procedure_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public short_func_definition()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public short_func_definition(procedure_definition _procdef)
		{
			this._procdef=_procdef;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public short_func_definition(procedure_definition _procdef,SourceContext sc)
		{
			this._procdef=_procdef;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public short_func_definition(procedure_header _proc_header,proc_block _proc_body,bool _is_short_definition,procedure_definition _procdef)
		{
			this._proc_header=_proc_header;
			this._proc_body=_proc_body;
			this._is_short_definition=_is_short_definition;
			this._procdef=_procdef;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public short_func_definition(procedure_header _proc_header,proc_block _proc_body,bool _is_short_definition,procedure_definition _procdef,SourceContext sc)
		{
			this._proc_header=_proc_header;
			this._proc_body=_proc_body;
			this._is_short_definition=_is_short_definition;
			this._procdef=_procdef;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected procedure_definition _procdef;

		///<summary>
		///
		///</summary>
		public procedure_definition procdef
		{
			get
			{
				return _procdef;
			}
			set
			{
				_procdef=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			short_func_definition copy = new short_func_definition();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (proc_header != null)
			{
				copy.proc_header = (procedure_header)proc_header.Clone();
				copy.proc_header.Parent = copy;
			}
			if (proc_body != null)
			{
				copy.proc_body = (proc_block)proc_body.Clone();
				copy.proc_body.Parent = copy;
			}
			copy.is_short_definition = is_short_definition;
			if (procdef != null)
			{
				copy.procdef = (procedure_definition)procdef.Clone();
				copy.procdef.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new short_func_definition TypedClone()
		{
			return Clone() as short_func_definition;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (proc_header != null)
				proc_header.Parent = this;
			if (proc_body != null)
				proc_body.Parent = this;
			if (procdef != null)
				procdef.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			proc_header?.FillParentsInAllChilds();
			proc_body?.FillParentsInAllChilds();
			procdef?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 3;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return proc_header;
					case 1:
						return proc_body;
					case 2:
						return procdef;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						proc_header = (procedure_header)value;
						break;
					case 1:
						proc_body = (proc_block)value;
						break;
					case 2:
						procdef = (procedure_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class no_type_foreach : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public no_type_foreach()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public no_type_foreach(type_definition_attr_list _attr_list)
		{
			this._attr_list=_attr_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public no_type_foreach(type_definition_attr_list _attr_list,SourceContext sc)
		{
			this._attr_list=_attr_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			no_type_foreach copy = new no_type_foreach();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new no_type_foreach TypedClone()
		{
			return Clone() as no_type_foreach;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class matching_expression : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public matching_expression()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public matching_expression(expression _left,expression _right)
		{
			this._left=_left;
			this._right=_right;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public matching_expression(expression _left,expression _right,SourceContext sc)
		{
			this._left=_left;
			this._right=_right;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _left;
		protected expression _right;

		///<summary>
		///
		///</summary>
		public expression left
		{
			get
			{
				return _left;
			}
			set
			{
				_left=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression right
		{
			get
			{
				return _right;
			}
			set
			{
				_right=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			matching_expression copy = new matching_expression();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (left != null)
			{
				copy.left = (expression)left.Clone();
				copy.left.Parent = copy;
			}
			if (right != null)
			{
				copy.right = (expression)right.Clone();
				copy.right.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new matching_expression TypedClone()
		{
			return Clone() as matching_expression;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (left != null)
				left.Parent = this;
			if (right != null)
				right.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			left?.FillParentsInAllChilds();
			right?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return left;
					case 1:
						return right;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						left = (expression)value;
						break;
					case 1:
						right = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class closure_substituting_node : ident
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public closure_substituting_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public closure_substituting_node(dot_node _substitution)
		{
			this._substitution=_substitution;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public closure_substituting_node(dot_node _substitution,SourceContext sc)
		{
			this._substitution=_substitution;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public closure_substituting_node(string _name,dot_node _substitution)
		{
			this._name=_name;
			this._substitution=_substitution;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public closure_substituting_node(string _name,dot_node _substitution,SourceContext sc)
		{
			this._name=_name;
			this._substitution=_substitution;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected dot_node _substitution;

		///<summary>
		///
		///</summary>
		public dot_node substitution
		{
			get
			{
				return _substitution;
			}
			set
			{
				_substitution=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			closure_substituting_node copy = new closure_substituting_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			if (substitution != null)
			{
				copy.substitution = (dot_node)substitution.Clone();
				copy.substitution.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new closure_substituting_node TypedClone()
		{
			return Clone() as closure_substituting_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (substitution != null)
				substitution.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			substitution?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return substitution;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						substitution = (dot_node)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class sequence_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public sequence_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sequence_type(type_definition _elements_type)
		{
			this._elements_type=_elements_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sequence_type(type_definition _elements_type,SourceContext sc)
		{
			this._elements_type=_elements_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sequence_type(type_definition_attr_list _attr_list,type_definition _elements_type)
		{
			this._attr_list=_attr_list;
			this._elements_type=_elements_type;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sequence_type(type_definition_attr_list _attr_list,type_definition _elements_type,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._elements_type=_elements_type;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _elements_type;

		///<summary>
		///Тип элементов
		///</summary>
		public type_definition elements_type
		{
			get
			{
				return _elements_type;
			}
			set
			{
				_elements_type=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			sequence_type copy = new sequence_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (elements_type != null)
			{
				copy.elements_type = (type_definition)elements_type.Clone();
				copy.elements_type.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new sequence_type TypedClone()
		{
			return Clone() as sequence_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (elements_type != null)
				elements_type.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			elements_type?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return elements_type;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						elements_type = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class modern_proc_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public modern_proc_type()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public modern_proc_type(type_definition _aloneparam,enumerator_list _el,type_definition _res)
		{
			this._aloneparam=_aloneparam;
			this._el=_el;
			this._res=_res;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public modern_proc_type(type_definition _aloneparam,enumerator_list _el,type_definition _res,SourceContext sc)
		{
			this._aloneparam=_aloneparam;
			this._el=_el;
			this._res=_res;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public modern_proc_type(type_definition_attr_list _attr_list,type_definition _aloneparam,enumerator_list _el,type_definition _res)
		{
			this._attr_list=_attr_list;
			this._aloneparam=_aloneparam;
			this._el=_el;
			this._res=_res;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public modern_proc_type(type_definition_attr_list _attr_list,type_definition _aloneparam,enumerator_list _el,type_definition _res,SourceContext sc)
		{
			this._attr_list=_attr_list;
			this._aloneparam=_aloneparam;
			this._el=_el;
			this._res=_res;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _aloneparam;
		protected enumerator_list _el;
		protected type_definition _res;

		///<summary>
		///
		///</summary>
		public type_definition aloneparam
		{
			get
			{
				return _aloneparam;
			}
			set
			{
				_aloneparam=value;
			}
		}

		///<summary>
		///
		///</summary>
		public enumerator_list el
		{
			get
			{
				return _el;
			}
			set
			{
				_el=value;
			}
		}

		///<summary>
		///
		///</summary>
		public type_definition res
		{
			get
			{
				return _res;
			}
			set
			{
				_res=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			modern_proc_type copy = new modern_proc_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			if (aloneparam != null)
			{
				copy.aloneparam = (type_definition)aloneparam.Clone();
				copy.aloneparam.Parent = copy;
			}
			if (el != null)
			{
				copy.el = (enumerator_list)el.Clone();
				copy.el.Parent = copy;
			}
			if (res != null)
			{
				copy.res = (type_definition)res.Clone();
				copy.res.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new modern_proc_type TypedClone()
		{
			return Clone() as modern_proc_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
			if (aloneparam != null)
				aloneparam.Parent = this;
			if (el != null)
				el.Parent = this;
			if (res != null)
				res.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
			aloneparam?.FillParentsInAllChilds();
			el?.FillParentsInAllChilds();
			res?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 4;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
					case 1:
						return aloneparam;
					case 2:
						return el;
					case 3:
						return res;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
					case 1:
						aloneparam = (type_definition)value;
						break;
					case 2:
						el = (enumerator_list)value;
						break;
					case 3:
						res = (type_definition)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class yield_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public yield_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_node(expression _ex)
		{
			this._ex=_ex;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_node(expression _ex,SourceContext sc)
		{
			this._ex=_ex;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _ex;

		///<summary>
		///
		///</summary>
		public expression ex
		{
			get
			{
				return _ex;
			}
			set
			{
				_ex=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			yield_node copy = new yield_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (ex != null)
			{
				copy.ex = (expression)ex.Clone();
				copy.ex.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new yield_node TypedClone()
		{
			return Clone() as yield_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (ex != null)
				ex.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			ex?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return ex;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						ex = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class template_operator_name : template_type_name
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public template_operator_name()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_operator_name(operator_name_ident _opname)
		{
			this._opname=_opname;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_operator_name(operator_name_ident _opname,SourceContext sc)
		{
			this._opname=_opname;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_operator_name(string _name,ident_list _template_args,operator_name_ident _opname)
		{
			this._name=_name;
			this._template_args=_template_args;
			this._opname=_opname;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public template_operator_name(string _name,ident_list _template_args,operator_name_ident _opname,SourceContext sc)
		{
			this._name=_name;
			this._template_args=_template_args;
			this._opname=_opname;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected operator_name_ident _opname;

		///<summary>
		///
		///</summary>
		public operator_name_ident opname
		{
			get
			{
				return _opname;
			}
			set
			{
				_opname=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			template_operator_name copy = new template_operator_name();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			if (template_args != null)
			{
				copy.template_args = (ident_list)template_args.Clone();
				copy.template_args.Parent = copy;
			}
			if (opname != null)
			{
				copy.opname = (operator_name_ident)opname.Clone();
				copy.opname.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new template_operator_name TypedClone()
		{
			return Clone() as template_operator_name;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (template_args != null)
				template_args.Parent = this;
			if (opname != null)
				opname.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			template_args?.FillParentsInAllChilds();
			opname?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return template_args;
					case 1:
						return opname;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						template_args = (ident_list)value;
						break;
					case 1:
						opname = (operator_name_ident)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class semantic_addr_value : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public semantic_addr_value()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_addr_value(Object _expr)
		{
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_addr_value(Object _expr,SourceContext sc)
		{
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected Object _expr;

		///<summary>
		///
		///</summary>
		public Object expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			semantic_addr_value copy = new semantic_addr_value();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.expr = expr;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new semantic_addr_value TypedClone()
		{
			return Clone() as semantic_addr_value;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class pair_type_stlist : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public pair_type_stlist()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public pair_type_stlist(type_definition _tn,statement_list _exprs)
		{
			this._tn=_tn;
			this._exprs=_exprs;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public pair_type_stlist(type_definition _tn,statement_list _exprs,SourceContext sc)
		{
			this._tn=_tn;
			this._exprs=_exprs;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected type_definition _tn;
		protected statement_list _exprs;

		///<summary>
		///
		///</summary>
		public type_definition tn
		{
			get
			{
				return _tn;
			}
			set
			{
				_tn=value;
			}
		}

		///<summary>
		///
		///</summary>
		public statement_list exprs
		{
			get
			{
				return _exprs;
			}
			set
			{
				_exprs=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			pair_type_stlist copy = new pair_type_stlist();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (tn != null)
			{
				copy.tn = (type_definition)tn.Clone();
				copy.tn.Parent = copy;
			}
			if (exprs != null)
			{
				copy.exprs = (statement_list)exprs.Clone();
				copy.exprs.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new pair_type_stlist TypedClone()
		{
			return Clone() as pair_type_stlist;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (tn != null)
				tn.Parent = this;
			if (exprs != null)
				exprs.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			tn?.FillParentsInAllChilds();
			exprs?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return tn;
					case 1:
						return exprs;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						tn = (type_definition)value;
						break;
					case 1:
						exprs = (statement_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class assign_tuple : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public assign_tuple()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public assign_tuple(addressed_value_list _vars,expression _expr)
		{
			this._vars=_vars;
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public assign_tuple(addressed_value_list _vars,expression _expr,SourceContext sc)
		{
			this._vars=_vars;
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value_list _vars;
		protected expression _expr;

		///<summary>
		///
		///</summary>
		public addressed_value_list vars
		{
			get
			{
				return _vars;
			}
			set
			{
				_vars=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression expr
		{
			get
			{
				return _expr;
			}
			set
			{
				_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			assign_tuple copy = new assign_tuple();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (vars != null)
			{
				copy.vars = (addressed_value_list)vars.Clone();
				copy.vars.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new assign_tuple TypedClone()
		{
			return Clone() as assign_tuple;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (vars != null)
				vars.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			vars?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return vars;
					case 1:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						vars = (addressed_value_list)value;
						break;
					case 1:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class addressed_value_list : syntax_tree_node
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public addressed_value_list()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public addressed_value_list(List<addressed_value> _variables)
		{
			this._variables=_variables;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public addressed_value_list(List<addressed_value> _variables,SourceContext sc)
		{
			this._variables=_variables;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public addressed_value_list(addressed_value elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<addressed_value> _variables=new List<addressed_value>();

		///<summary>
		///
		///</summary>
		public List<addressed_value> variables
		{
			get
			{
				return _variables;
			}
			set
			{
				_variables=value;
			}
		}


		public addressed_value_list Add(addressed_value elem, SourceContext sc = null)
		{
			variables.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(addressed_value el)
		{
			variables.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<addressed_value> els)
		{
			variables.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params addressed_value[] els)
		{
			variables.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(addressed_value el)
		{
			var ind = variables.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(addressed_value el, addressed_value newel)
		{
			variables.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(addressed_value el, IEnumerable<addressed_value> newels)
		{
			variables.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(addressed_value el, addressed_value newel)
		{
			variables.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(addressed_value el, IEnumerable<addressed_value> newels)
		{
			variables.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(addressed_value el)
		{
			return variables.Remove(el);
		}
		
		public void ReplaceInList(addressed_value el, addressed_value newel)
		{
			variables[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(addressed_value el, IEnumerable<addressed_value> newels)
		{
			var ind = FindIndexInList(el);
			variables.RemoveAt(ind);
			variables.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<addressed_value> match)
		{
			return variables.RemoveAll(match);
		}
		
		public addressed_value Last()
		{
			return variables[variables.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			addressed_value_list copy = new addressed_value_list();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (variables != null)
			{
				foreach (addressed_value elem in variables)
				{
					if (elem != null)
					{
						copy.Add((addressed_value)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new addressed_value_list TypedClone()
		{
			return Clone() as addressed_value_list;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (variables != null)
			{
				foreach (var child in variables)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (variables != null)
			{
				foreach (var child in variables)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (variables == null ? 0 : variables.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(variables != null)
				{
					if(index_counter < variables.Count)
					{
						return variables[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(variables != null)
				{
					if(index_counter < variables.Count)
					{
						variables[index_counter]= (addressed_value)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class tuple_node : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public tuple_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public tuple_node(expression_list _el)
		{
			this._el=_el;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public tuple_node(expression_list _el,SourceContext sc)
		{
			this._el=_el;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression_list _el;

		///<summary>
		///
		///</summary>
		public expression_list el
		{
			get
			{
				return _el;
			}
			set
			{
				_el=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			tuple_node copy = new tuple_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (el != null)
			{
				copy.el = (expression_list)el.Clone();
				copy.el.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new tuple_node TypedClone()
		{
			return Clone() as tuple_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (el != null)
				el.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			el?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return el;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						el = (expression_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class uses_closure : uses_list
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public uses_closure()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_closure(List<uses_list> _listunitsections)
		{
			this._listunitsections=_listunitsections;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_closure(List<uses_list> _listunitsections,SourceContext sc)
		{
			this._listunitsections=_listunitsections;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_closure(List<unit_or_namespace> _units,List<uses_list> _listunitsections)
		{
			this._units=_units;
			this._listunitsections=_listunitsections;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public uses_closure(List<unit_or_namespace> _units,List<uses_list> _listunitsections,SourceContext sc)
		{
			this._units=_units;
			this._listunitsections=_listunitsections;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public uses_closure(uses_list elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected List<uses_list> _listunitsections=new List<uses_list>();

		///<summary>
		///
		///</summary>
		public List<uses_list> listunitsections
		{
			get
			{
				return _listunitsections;
			}
			set
			{
				_listunitsections=value;
			}
		}


		public uses_closure Add(uses_list elem, SourceContext sc = null)
		{
			listunitsections.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(uses_list el)
		{
			listunitsections.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<uses_list> els)
		{
			listunitsections.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params uses_list[] els)
		{
			listunitsections.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(uses_list el)
		{
			var ind = listunitsections.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(uses_list el, uses_list newel)
		{
			listunitsections.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(uses_list el, IEnumerable<uses_list> newels)
		{
			listunitsections.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(uses_list el, uses_list newel)
		{
			listunitsections.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(uses_list el, IEnumerable<uses_list> newels)
		{
			listunitsections.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(uses_list el)
		{
			return listunitsections.Remove(el);
		}
		
		public void ReplaceInList(uses_list el, uses_list newel)
		{
			listunitsections[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(uses_list el, IEnumerable<uses_list> newels)
		{
			var ind = FindIndexInList(el);
			listunitsections.RemoveAt(ind);
			listunitsections.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<uses_list> match)
		{
			return listunitsections.RemoveAll(match);
		}
		
		public uses_list Last()
		{
			return listunitsections[listunitsections.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			uses_closure copy = new uses_closure();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (units != null)
			{
				foreach (unit_or_namespace elem in units)
				{
					if (elem != null)
					{
						copy.Add((unit_or_namespace)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			if (listunitsections != null)
			{
				foreach (uses_list elem in listunitsections)
				{
					if (elem != null)
					{
						copy.Add((uses_list)elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new uses_closure TypedClone()
		{
			return Clone() as uses_closure;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (units != null)
			{
				foreach (var child in units)
					if (child != null)
						child.Parent = this;
			}
			if (listunitsections != null)
			{
				foreach (var child in listunitsections)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			if (units != null)
			{
				foreach (var child in units)
					child?.FillParentsInAllChilds();
			}
			if (listunitsections != null)
			{
				foreach (var child in listunitsections)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (units == null ? 0 : units.Count) + (listunitsections == null ? 0 : listunitsections.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(units != null)
				{
					if(index_counter < units.Count)
					{
						return units[index_counter];
					}
					else
						index_counter = index_counter - units.Count;
				}
				if(listunitsections != null)
				{
					if(index_counter < listunitsections.Count)
					{
						return listunitsections[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(units != null)
				{
					if(index_counter < units.Count)
					{
						units[index_counter]= (unit_or_namespace)value;
						return;
					}
					else
						index_counter = index_counter - units.Count;
				}
				if(listunitsections != null)
				{
					if(index_counter < listunitsections.Count)
					{
						listunitsections[index_counter]= (uses_list)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class dot_question_node : addressed_value_funcname
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public dot_question_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public dot_question_node(addressed_value _left,addressed_value _right)
		{
			this._left=_left;
			this._right=_right;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public dot_question_node(addressed_value _left,addressed_value _right,SourceContext sc)
		{
			this._left=_left;
			this._right=_right;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _left;
		protected addressed_value _right;

		///<summary>
		///
		///</summary>
		public addressed_value left
		{
			get
			{
				return _left;
			}
			set
			{
				_left=value;
			}
		}

		///<summary>
		///
		///</summary>
		public addressed_value right
		{
			get
			{
				return _right;
			}
			set
			{
				_right=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			dot_question_node copy = new dot_question_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (left != null)
			{
				copy.left = (addressed_value)left.Clone();
				copy.left.Parent = copy;
			}
			if (right != null)
			{
				copy.right = (addressed_value)right.Clone();
				copy.right.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new dot_question_node TypedClone()
		{
			return Clone() as dot_question_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (left != null)
				left.Parent = this;
			if (right != null)
				right.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			left?.FillParentsInAllChilds();
			right?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return left;
					case 1:
						return right;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						left = (addressed_value)value;
						break;
					case 1:
						right = (addressed_value)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class slice_expr : dereference
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public slice_expr()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public slice_expr(addressed_value _v,expression _from,expression _to,expression _step)
		{
			this._v=_v;
			this._from=_from;
			this._to=_to;
			this._step=_step;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public slice_expr(addressed_value _v,expression _from,expression _to,expression _step,SourceContext sc)
		{
			this._v=_v;
			this._from=_from;
			this._to=_to;
			this._step=_step;
			source_context = sc;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public slice_expr(addressed_value _dereferencing_value,addressed_value _v,expression _from,expression _to,expression _step)
		{
			this._dereferencing_value=_dereferencing_value;
			this._v=_v;
			this._from=_from;
			this._to=_to;
			this._step=_step;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public slice_expr(addressed_value _dereferencing_value,addressed_value _v,expression _from,expression _to,expression _step,SourceContext sc)
		{
			this._dereferencing_value=_dereferencing_value;
			this._v=_v;
			this._from=_from;
			this._to=_to;
			this._step=_step;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected addressed_value _v;
		protected expression _from;
		protected expression _to;
		protected expression _step;

		///<summary>
		///
		///</summary>
		public addressed_value v
		{
			get
			{
				return _v;
			}
			set
			{
				_v=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression from
		{
			get
			{
				return _from;
			}
			set
			{
				_from=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression to
		{
			get
			{
				return _to;
			}
			set
			{
				_to=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression step
		{
			get
			{
				return _step;
			}
			set
			{
				_step=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			slice_expr copy = new slice_expr();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (dereferencing_value != null)
			{
				copy.dereferencing_value = (addressed_value)dereferencing_value.Clone();
				copy.dereferencing_value.Parent = copy;
			}
			if (v != null)
			{
				copy.v = (addressed_value)v.Clone();
				copy.v.Parent = copy;
			}
			if (from != null)
			{
				copy.from = (expression)from.Clone();
				copy.from.Parent = copy;
			}
			if (to != null)
			{
				copy.to = (expression)to.Clone();
				copy.to.Parent = copy;
			}
			if (step != null)
			{
				copy.step = (expression)step.Clone();
				copy.step.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new slice_expr TypedClone()
		{
			return Clone() as slice_expr;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (dereferencing_value != null)
				dereferencing_value.Parent = this;
			if (v != null)
				v.Parent = this;
			if (from != null)
				from.Parent = this;
			if (to != null)
				to.Parent = this;
			if (step != null)
				step.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			dereferencing_value?.FillParentsInAllChilds();
			v?.FillParentsInAllChilds();
			from?.FillParentsInAllChilds();
			to?.FillParentsInAllChilds();
			step?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 5;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 5;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return dereferencing_value;
					case 1:
						return v;
					case 2:
						return from;
					case 3:
						return to;
					case 4:
						return step;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						dereferencing_value = (addressed_value)value;
						break;
					case 1:
						v = (addressed_value)value;
						break;
					case 2:
						from = (expression)value;
						break;
					case 3:
						to = (expression)value;
						break;
					case 4:
						step = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class no_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public no_type()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public no_type(type_definition_attr_list _attr_list)
		{
			this._attr_list=_attr_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public no_type(type_definition_attr_list _attr_list,SourceContext sc)
		{
			this._attr_list=_attr_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			no_type copy = new no_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new no_type TypedClone()
		{
			return Clone() as no_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Неопознанный идентификатор. Откладывает определение необходимости захвата имени как поля класса до этапа семантики.
	///</summary>
	[Serializable]
	public partial class yield_unknown_ident : ident
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public yield_unknown_ident()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_unknown_ident(string _name)
		{
			this._name=_name;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_unknown_ident(string _name,SourceContext sc)
		{
			this._name=_name;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			yield_unknown_ident copy = new yield_unknown_ident();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.name = name;
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new yield_unknown_ident TypedClone()
		{
			return Clone() as yield_unknown_ident;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Узел для вычисления типа выражения используемого в теле функции-итератора (с yield). Используется для описаний всех переменных с автовыводом типов в теле yield: например, для var a := 1; Дело в том, что эти переменные становятся полями класса, а для описания полей класса нужен тип
	///</summary>
	[Serializable]
	public partial class yield_unknown_expression_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public yield_unknown_expression_type()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_unknown_expression_type(type_definition_attr_list _attr_list)
		{
			this._attr_list=_attr_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_unknown_expression_type(type_definition_attr_list _attr_list,SourceContext sc)
		{
			this._attr_list=_attr_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			yield_unknown_expression_type copy = new yield_unknown_expression_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new yield_unknown_expression_type TypedClone()
		{
			return Clone() as yield_unknown_expression_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Узел для вычисления типа переменной используемой в теле foreach (с yield)
	///</summary>
	[Serializable]
	public partial class yield_unknown_foreach_type : type_definition
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public yield_unknown_foreach_type()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_unknown_foreach_type(type_definition_attr_list _attr_list)
		{
			this._attr_list=_attr_list;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_unknown_foreach_type(type_definition_attr_list _attr_list,SourceContext sc)
		{
			this._attr_list=_attr_list;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			yield_unknown_foreach_type copy = new yield_unknown_foreach_type();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (attr_list != null)
			{
				copy.attr_list = (type_definition_attr_list)attr_list.Clone();
				copy.attr_list.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new yield_unknown_foreach_type TypedClone()
		{
			return Clone() as yield_unknown_foreach_type;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (attr_list != null)
				attr_list.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			attr_list?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return attr_list;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						attr_list = (type_definition_attr_list)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class yield_sequence_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public yield_sequence_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_sequence_node(expression _ex)
		{
			this._ex=_ex;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public yield_sequence_node(expression _ex,SourceContext sc)
		{
			this._ex=_ex;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected expression _ex;

		///<summary>
		///
		///</summary>
		public expression ex
		{
			get
			{
				return _ex;
			}
			set
			{
				_ex=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			yield_sequence_node copy = new yield_sequence_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (ex != null)
			{
				copy.ex = (expression)ex.Clone();
				copy.ex.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new yield_sequence_node TypedClone()
		{
			return Clone() as yield_sequence_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (ex != null)
				ex.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			ex?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return ex;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						ex = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class assign_var_tuple : assign_tuple
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public assign_var_tuple()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public assign_var_tuple(addressed_value_list _vars,expression _expr)
		{
			this._vars=_vars;
			this._expr=_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public assign_var_tuple(addressed_value_list _vars,expression _expr,SourceContext sc)
		{
			this._vars=_vars;
			this._expr=_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			assign_var_tuple copy = new assign_var_tuple();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (vars != null)
			{
				copy.vars = (addressed_value_list)vars.Clone();
				copy.vars.Parent = copy;
			}
			if (expr != null)
			{
				copy.expr = (expression)expr.Clone();
				copy.expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new assign_var_tuple TypedClone()
		{
			return Clone() as assign_var_tuple;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (vars != null)
				vars.Parent = this;
			if (expr != null)
				expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			vars?.FillParentsInAllChilds();
			expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 2;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return vars;
					case 1:
						return expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						vars = (addressed_value_list)value;
						break;
					case 1:
						expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///
	///</summary>
	[Serializable]
	public partial class slice_expr_question : slice_expr
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public slice_expr_question()
		{

		}


		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public slice_expr_question(addressed_value _dereferencing_value,addressed_value _v,expression _from,expression _to,expression _step)
		{
			this._dereferencing_value=_dereferencing_value;
			this._v=_v;
			this._from=_from;
			this._to=_to;
			this._step=_step;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public slice_expr_question(addressed_value _dereferencing_value,addressed_value _v,expression _from,expression _to,expression _step,SourceContext sc)
		{
			this._dereferencing_value=_dereferencing_value;
			this._v=_v;
			this._from=_from;
			this._to=_to;
			this._step=_step;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			slice_expr_question copy = new slice_expr_question();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			if (dereferencing_value != null)
			{
				copy.dereferencing_value = (addressed_value)dereferencing_value.Clone();
				copy.dereferencing_value.Parent = copy;
			}
			if (v != null)
			{
				copy.v = (addressed_value)v.Clone();
				copy.v.Parent = copy;
			}
			if (from != null)
			{
				copy.from = (expression)from.Clone();
				copy.from.Parent = copy;
			}
			if (to != null)
			{
				copy.to = (expression)to.Clone();
				copy.to.Parent = copy;
			}
			if (step != null)
			{
				copy.step = (expression)step.Clone();
				copy.step.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new slice_expr_question TypedClone()
		{
			return Clone() as slice_expr_question;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (dereferencing_value != null)
				dereferencing_value.Parent = this;
			if (v != null)
				v.Parent = this;
			if (from != null)
				from.Parent = this;
			if (to != null)
				to.Parent = this;
			if (step != null)
				step.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			dereferencing_value?.FillParentsInAllChilds();
			v?.FillParentsInAllChilds();
			from?.FillParentsInAllChilds();
			to?.FillParentsInAllChilds();
			step?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 5;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 5;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return dereferencing_value;
					case 1:
						return v;
					case 2:
						return from;
					case 3:
						return to;
					case 4:
						return step;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						dereferencing_value = (addressed_value)value;
						break;
					case 1:
						v = (addressed_value)value;
						break;
					case 2:
						from = (expression)value;
						break;
					case 3:
						to = (expression)value;
						break;
					case 4:
						step = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Узел, не генерирующий кода, но осуществляющий семантические проверки сахарных узлов. stat - это на самом деле statement. stat сделано типа object - чтобы оно автоматически не обходилось
	///</summary>
	[Serializable]
	public partial class semantic_check_sugared_statement_node : statement
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public semantic_check_sugared_statement_node()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_check_sugared_statement_node(object _typ,List<syntax_tree_node> _lst)
		{
			this._typ=_typ;
			this._lst=_lst;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public semantic_check_sugared_statement_node(object _typ,List<syntax_tree_node> _lst,SourceContext sc)
		{
			this._typ=_typ;
			this._lst=_lst;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		public semantic_check_sugared_statement_node(syntax_tree_node elem, SourceContext sc = null)
		{
			Add(elem, sc);
		    FillParentsInDirectChilds();
		}
		
		protected object _typ;
		protected List<syntax_tree_node> _lst=new List<syntax_tree_node>();

		///<summary>
		///
		///</summary>
		public object typ
		{
			get
			{
				return _typ;
			}
			set
			{
				_typ=value;
			}
		}

		///<summary>
		///
		///</summary>
		public List<syntax_tree_node> lst
		{
			get
			{
				return _lst;
			}
			set
			{
				_lst=value;
			}
		}


		public semantic_check_sugared_statement_node Add(syntax_tree_node elem, SourceContext sc = null)
		{
			lst.Add(elem);
			if (elem != null)
				elem.Parent = this;
			if (sc != null)
				source_context = sc;
			return this;
		}
		
		public void AddFirst(syntax_tree_node el)
		{
			lst.Insert(0, el);
			FillParentsInDirectChilds();
		}
		
		public void AddFirst(IEnumerable<syntax_tree_node> els)
		{
			lst.InsertRange(0, els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		public void AddMany(params syntax_tree_node[] els)
		{
			lst.AddRange(els);
			foreach (var el in els)
				if (el != null)
					el.Parent = this;
		}
		
		private int FindIndexInList(syntax_tree_node el)
		{
			var ind = lst.FindIndex(x => x == el);
			if (ind == -1)
				throw new Exception(string.Format("У списка {0} не найден элемент {1} среди дочерних\n", this, el));
			return ind;
		}
		
		public void InsertAfter(syntax_tree_node el, syntax_tree_node newel)
		{
			lst.Insert(FindIndexInList(el) + 1, newel);
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void InsertAfter(syntax_tree_node el, IEnumerable<syntax_tree_node> newels)
		{
			lst.InsertRange(FindIndexInList(el) + 1, newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public void InsertBefore(syntax_tree_node el, syntax_tree_node newel)
		{
			lst.Insert(FindIndexInList(el), newel);
			if (newel != null)
				newel.Parent = this;
		}
		
		public void InsertBefore(syntax_tree_node el, IEnumerable<syntax_tree_node> newels)
		{
			lst.InsertRange(FindIndexInList(el), newels);
			foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public bool Remove(syntax_tree_node el)
		{
			return lst.Remove(el);
		}
		
		public void ReplaceInList(syntax_tree_node el, syntax_tree_node newel)
		{
			lst[FindIndexInList(el)] = newel;
			if (newel != null)
			   	newel.Parent = this;
		}
		
		public void ReplaceInList(syntax_tree_node el, IEnumerable<syntax_tree_node> newels)
		{
			var ind = FindIndexInList(el);
			lst.RemoveAt(ind);
			lst.InsertRange(ind, newels);
		    foreach (var newel in newels)
				if (el != null)
					el.Parent = this;
		}
		
		public int RemoveAll(Predicate<syntax_tree_node> match)
		{
			return lst.RemoveAll(match);
		}
		
		public syntax_tree_node Last()
		{
			return lst[lst.Count - 1];
		}
		
		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			semantic_check_sugared_statement_node copy = new semantic_check_sugared_statement_node();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.typ = typ;
			if (lst != null)
			{
				foreach (syntax_tree_node elem in lst)
				{
					if (elem != null)
					{
						copy.Add(elem.Clone());
						copy.Last().Parent = copy;
					}
					else
						copy.Add(null);
				}
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new semantic_check_sugared_statement_node TypedClone()
		{
			return Clone() as semantic_check_sugared_statement_node;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (lst != null)
			{
				foreach (var child in lst)
					if (child != null)
						child.Parent = this;
			}
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			if (lst != null)
			{
				foreach (var child in lst)
					child?.FillParentsInAllChilds();
			}
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 0;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 0 + (lst == null ? 0 : lst.Count);
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(lst != null)
				{
					if(index_counter < lst.Count)
					{
						return lst[index_counter];
					}
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				Int32 index_counter=ind - 0;
				if(lst != null)
				{
					if(index_counter < lst.Count)
					{
						lst[index_counter]= (syntax_tree_node)value;
						return;
					}
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Обёртка для сахарного выражения, хранящего сахарный узел для семантических проверок и новое выражение после удаления синтаксического сахара
	///</summary>
	[Serializable]
	public partial class sugared_expression : expression
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public sugared_expression()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sugared_expression(object _sugared_expr,expression _new_expr)
		{
			this._sugared_expr=_sugared_expr;
			this._new_expr=_new_expr;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sugared_expression(object _sugared_expr,expression _new_expr,SourceContext sc)
		{
			this._sugared_expr=_sugared_expr;
			this._new_expr=_new_expr;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected object _sugared_expr;
		protected expression _new_expr;

		///<summary>
		///
		///</summary>
		public object sugared_expr
		{
			get
			{
				return _sugared_expr;
			}
			set
			{
				_sugared_expr=value;
			}
		}

		///<summary>
		///
		///</summary>
		public expression new_expr
		{
			get
			{
				return _new_expr;
			}
			set
			{
				_new_expr=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			sugared_expression copy = new sugared_expression();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.sugared_expr = sugared_expr;
			if (new_expr != null)
			{
				copy.new_expr = (expression)new_expr.Clone();
				copy.new_expr.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new sugared_expression TypedClone()
		{
			return Clone() as sugared_expression;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (new_expr != null)
				new_expr.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			new_expr?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return new_expr;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						new_expr = (expression)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}


	///<summary>
	///Обёртка для сахарного адресуемого значения, хранящего сахарный узел для семантических проверок и новое выражение после удаления синтаксического сахара
	///</summary>
	[Serializable]
	public partial class sugared_addressed_value : addressed_value
	{

		///<summary>
		///Конструктор без параметров.
		///</summary>
		public sugared_addressed_value()
		{

		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sugared_addressed_value(object _sugared_expr,addressed_value _new_addr_value)
		{
			this._sugared_expr=_sugared_expr;
			this._new_addr_value=_new_addr_value;
			FillParentsInDirectChilds();
		}

		///<summary>
		///Конструктор с параметрами.
		///</summary>
		public sugared_addressed_value(object _sugared_expr,addressed_value _new_addr_value,SourceContext sc)
		{
			this._sugared_expr=_sugared_expr;
			this._new_addr_value=_new_addr_value;
			source_context = sc;
			FillParentsInDirectChilds();
		}
		protected object _sugared_expr;
		protected addressed_value _new_addr_value;

		///<summary>
		///
		///</summary>
		public object sugared_expr
		{
			get
			{
				return _sugared_expr;
			}
			set
			{
				_sugared_expr=value;
			}
		}

		///<summary>
		///
		///</summary>
		public addressed_value new_addr_value
		{
			get
			{
				return _new_addr_value;
			}
			set
			{
				_new_addr_value=value;
			}
		}


		/// <summary> Создает копию узла </summary>
		public override syntax_tree_node Clone()
		{
			sugared_addressed_value copy = new sugared_addressed_value();
			copy.Parent = this.Parent;
			if (source_context != null)
				copy.source_context = new SourceContext(source_context);
			if (attributes != null)
			{
				copy.attributes = (attribute_list)attributes.Clone();
				copy.attributes.Parent = copy;
			}
			copy.sugared_expr = sugared_expr;
			if (new_addr_value != null)
			{
				copy.new_addr_value = (addressed_value)new_addr_value.Clone();
				copy.new_addr_value.Parent = copy;
			}
			return copy;
		}

		/// <summary> Получает копию данного узла корректного типа </summary>
		public new sugared_addressed_value TypedClone()
		{
			return Clone() as sugared_addressed_value;
		}

		///<summary> Заполняет поля Parent в непосредственных дочерних узлах </summary>
		public override void FillParentsInDirectChilds()
		{
			if (attributes != null)
				attributes.Parent = this;
			if (new_addr_value != null)
				new_addr_value.Parent = this;
		}

		///<summary> Заполняет поля Parent во всем поддереве </summary>
		public override void FillParentsInAllChilds()
		{
			FillParentsInDirectChilds();
			attributes?.FillParentsInAllChilds();
			new_addr_value?.FillParentsInAllChilds();
		}

		///<summary>
		///Свойство для получения количества всех подузлов без элементов поля типа List
		///</summary>
		public override Int32 subnodes_without_list_elements_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Свойство для получения количества всех подузлов. Подузлом также считается каждый элемент поля типа List
		///</summary>
		public override Int32 subnodes_count
		{
			get
			{
				return 1;
			}
		}
		///<summary>
		///Индексатор для получения всех подузлов
		///</summary>
		public override syntax_tree_node this[Int32 ind]
		{
			get
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						return new_addr_value;
				}
				return null;
			}
			set
			{
				if(subnodes_count == 0 || ind < 0 || ind > subnodes_count-1)
					throw new IndexOutOfRangeException();
				switch(ind)
				{
					case 0:
						new_addr_value = (addressed_value)value;
						break;
				}
			}
		}
		///<summary>
		///Метод для обхода дерева посетителем
		///</summary>
		///<param name="visitor">Объект-посетитель.</param>
		///<returns>Return value is void</returns>
		public override void visit(IVisitor visitor)
		{
			visitor.visit(this);
		}

	}



}

