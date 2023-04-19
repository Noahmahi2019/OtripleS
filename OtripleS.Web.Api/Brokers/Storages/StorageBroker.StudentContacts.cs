﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OtripleS.Web.Api.Models.StudentContacts;

namespace OtripleS.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<StudentContact> StudentContacts { get; set; }

        public async ValueTask<StudentContact> InsertStudentContactAsync(
            StudentContact studentContact)
        {
            var broker = new StorageBroker(this.configuration);

            EntityEntry<StudentContact> studentContactEntityEntry =
                await broker.StudentContacts.AddAsync(entity: studentContact);

            await broker.SaveChangesAsync();

            return studentContactEntityEntry.Entity;
        }

        public IQueryable<StudentContact> SelectAllStudentContacts() =>
            this.StudentContacts;

        public async ValueTask<StudentContact> SelectStudentContactByIdAsync(Guid StudentContactId) =>
             await SelectStudentContactByIdAsync(StudentContactId);

        public async ValueTask<StudentContact> UpdateStudentContactAsync(
            StudentContact studentContact)
        {
            var broker = new StorageBroker(this.configuration);

            EntityEntry<StudentContact> studentContactEntityEntry =
                broker.StudentContacts.Update(entity: studentContact);

            await broker.SaveChangesAsync();

            return studentContactEntityEntry.Entity;
        }

        public async ValueTask<StudentContact> DeleteStudentContactAsync(
            StudentContact studentContact)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<StudentContact> studentContactEntityEntry =
                broker.StudentContacts.Remove(entity: studentContact);

            await broker.SaveChangesAsync();

            return studentContactEntityEntry.Entity;
        }
    }
}
