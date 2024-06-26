﻿namespace Signature.WebAPI.Entities.Requests
{
    public class SetAdjustmentsLossesRequest
    {
        #region Fields
        private string _companyNum;
        private string _user;
        private List<AdjustmentsLosses> _AdjustmentsLosses;
        #endregion

        #region Getters & Setters
        public string CompanyNum
        {
            get
            {
                return _companyNum;
            }

            set
            {
                _companyNum = value;
            }
        }

        public string User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }

        public List<AdjustmentsLosses> AdjustmentsLosses
        {
            get
            {
                return _AdjustmentsLosses;
            }

            set
            {
                _AdjustmentsLosses = value;
            }
        }
        #endregion

        #region Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SetAdjustmentsLossesRequest()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            CompanyNum = string.Empty;
            User = string.Empty;
            AdjustmentsLosses = new List<AdjustmentsLosses>();
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SetAdjustmentsLossesRequest(string _companyNum, string _user, List<AdjustmentsLosses> _AdjustmentsLosses)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            CompanyNum = _companyNum;
            User = _user;
            AdjustmentsLosses = _AdjustmentsLosses;
        }
        #endregion
    }

    /// <summary>
    /// AdjustementsLosses
    /// </summary>
#pragma warning disable S4035 // Classes implementing "IEquatable<T>" should be sealed
    public class AdjustmentsLosses : IEquatable<AdjustmentsLosses>
#pragma warning restore S4035 // Classes implementing "IEquatable<T>" should be sealed
    {
        #region Propiedades
        public int Id { get; set; }
        public string NCompany { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Article { get; set; }
        public int Units { get; set; }
        public string Operator { get; set; }
        public string Reason { get; set; }
        public string Observations { get; set; }
        public bool Validated { get; set; }
        public string Store { get; set; }
        public string Warehouse { get; set; }

        #endregion

        #region Constructor
        ///// <summary>
        ///// Use AdjustementsLosses.Builder() for instance creation instead.
        ///// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AdjustmentsLosses()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        /// <summary>
        /// Constructor by parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nCompany"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="article"></param>
        /// <param name="units"></param>
        /// <param name="operato"></param>
        /// <param name="reason"></param>
        /// <param name="observations"></param>
        /// <param name="validated"></param>
        /// <param name="store"></param>
        /// <param name="warehouse"></param>
        public AdjustmentsLosses(int id, string nCompany, string date, string time, string article, int units, string operato, string reason, string observations, bool validated, string store, string warehouse)
        {
            Id = id;
            NCompany = nCompany;
            Date = date;
            Time = time;
            Article = article;
            Units = units;
            Operator = operato;
            Reason = reason;
            Observations = observations;
            Validated = validated;
            Store = store;
            Warehouse = warehouse;

        }
        #endregion

        #region methods generated by swagger applying API-First
        /// <summary>
        /// Returns builder of Articulo.
        /// </summary>
        /// <returns>ArticuloBuilder</returns>
        public static AdjustmentsLossesBuilder Builder()
        {
            return new AdjustmentsLossesBuilder();
        }

        /// <summary>
        /// Returns ArticuloBuilder with properties set.
        /// Use it to change properties.
        /// </summary>
        /// <returns>ArticuloBuilder</returns>
        public AdjustmentsLossesBuilder With()
        {
            return Builder()
            .Id(Id)
            .NCompany(NCompany)
            .Date(Date)
            .Time(Time)
            .Article(Article)
            .Units(Units)
            .Operator(Operator)
            .Reason(Reason)
            .Observations(Observations)
            .Validated(Validated)
            .Store(Store)
            .Warehouse(Warehouse);

        }

#pragma warning disable S2190 // Recursion should not be infinite
        public override string ToString()
#pragma warning restore S2190 // Recursion should not be infinite
        {
            return ToString();
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            return Equals(obj);
        }

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        public bool Equals(AdjustmentsLosses other)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
            return Equals((object)other);
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }

        /// <summary>
        /// Implementation of == operator for (Articulo.
        /// </summary>
        /// <param name="left">Compared (Articulo</param>
        /// <param name="right">Compared (Articulo</param>
        /// <returns>true if compared items are equals, false otherwise</returns>
        public static bool operator ==(AdjustmentsLosses left, AdjustmentsLosses right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implementation of != operator for (Articulo.
        /// </summary>
        /// <param name="left">Compared (Articulo</param>
        /// <param name="right">Compared (Articulo</param>
        /// <returns>true if compared items are not equals, false otherwise</returns>
        public static bool operator !=(AdjustmentsLosses left, AdjustmentsLosses right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Builder of Articulo.
        /// </summary>
        public sealed class AdjustmentsLossesBuilder
        {
            private int _Id;
            private string _NCompany;
            private string _Date;
            private string _Time;
            private string _Article;
            private int _Units;
            private string _Operator;
            private string _Reason;
            private string _Observations;
            private bool _Validated;
            private string _Store;
            private string _Warehouse;
            private decimal _Pvp;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            internal AdjustmentsLossesBuilder()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            {
                SetupDefaults();
            }

#pragma warning disable S1186 // Methods should not be empty
            private void SetupDefaults()
#pragma warning restore S1186 // Methods should not be empty
            {
            }


            public AdjustmentsLossesBuilder Id(int value)
            {
                _Id = value;
                return this;
            }


            public AdjustmentsLossesBuilder NCompany(string value)
            {
                _NCompany = value;
                return this;
            }


            public AdjustmentsLossesBuilder Date(string value)
            {
                _Date = value;
                return this;
            }


            public AdjustmentsLossesBuilder Time(string value)
            {
                _Time = value;
                return this;
            }


            public AdjustmentsLossesBuilder Article(string value)
            {
                _Article = value;
                return this;
            }


            public AdjustmentsLossesBuilder Units(int value)
            {
                _Units = value;
                return this;
            }


            public AdjustmentsLossesBuilder Operator(string value)
            {
                _Operator = value;
                return this;
            }


            public AdjustmentsLossesBuilder Reason(string value)
            {
                _Reason = value;
                return this;
            }


            public AdjustmentsLossesBuilder Observations(string value)
            {
                _Observations = value;
                return this;
            }


            public AdjustmentsLossesBuilder Validated(bool value)
            {
                _Validated = value;
                return this;
            }


            public AdjustmentsLossesBuilder Store(string value)
            {
                _Store = value;
                return this;
            }


            public AdjustmentsLossesBuilder Warehouse(string value)
            {
                _Warehouse = value;
                return this;
            }


            public AdjustmentsLossesBuilder Pvp(decimal value)
            {
                _Pvp = value;
                return this;
            }




            /// <summary>
            /// Builds instance of AdjustementsLosses.
            /// </summary>
            /// <returns>AdjustementsLosses</returns>
            public AdjustmentsLosses Build()
            {
                Validate();
                return new AdjustmentsLosses()
                {
                    Id = _Id,
                    NCompany = _NCompany,
                    Date = _Date,
                    Time = _Time,
                    Article = _Article,
                    Units = _Units,
                    Operator = _Operator,
                    Reason = _Reason,
                    Observations = _Observations,
                    Validated = _Validated,
                    Store = _Store,
                    Warehouse = _Warehouse
                };
            }

            private void Validate()
            {
            }
        }

        #endregion API-First
    }
}