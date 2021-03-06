﻿using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YearGoal.Data.Repository.Interface;

namespace YearGoal.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDocumentStore _documentStore;
  

        public Repository()
        {
            _documentStore = new DocumentStore() { Url = "http://localhost:9090/", DefaultDatabase = "Metis" };
            _documentStore.Initialize();            
        }

        public void Add(T entity)
        {
            try
            {
                using (var documentSession = _documentStore.OpenSession())
                {
                    documentSession.Store(entity);                    
                    documentSession.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public T GetById(string Id)
        {
            T model;
            try
            {
                using (var documentSession = _documentStore.OpenSession())
                {
                    model = documentSession.Load<T>(Id);
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

            return model;
        }


        public bool Update(T newDocument, string Id)
        {
            
            try
            {
                using (var documentSession = _documentStore.OpenSession())
                {
                    var oldDocument = documentSession.Load<T>(Id);
                    newDocument = oldDocument;
                    documentSession.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new NotImplementedException();                
            }

            return true;
        }

        public void Remove(string Id)
        {
            try
            {
                using (var documentSession = _documentStore.OpenSession())
                {
                    var document = this.GetById(Id);
                    documentSession.Delete<T>(document);
                    documentSession.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }
    }
}
