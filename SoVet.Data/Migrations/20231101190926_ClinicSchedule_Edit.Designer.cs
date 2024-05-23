﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SoVet.Data;

#nullable disable

namespace SoVet.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231101190926_ClinicSchedule_Edit")]
    partial class ClinicSchedule_Edit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SoVet.Data.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Anamnesis")
                        .HasColumnType("text")
                        .HasColumnName("anamnesis");

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("change_date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<string>("Information")
                        .HasColumnType("text")
                        .HasColumnName("information");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("purpose");

                    b.Property<int>("RecommendationId")
                        .HasColumnType("integer")
                        .HasColumnName("recommendation_id");

                    b.HasKey("Id")
                        .HasName("pk_appointments");

                    b.HasIndex("EmployeeId")
                        .HasDatabaseName("ix_appointments_employee_id");

                    b.HasIndex("PatientId")
                        .HasDatabaseName("ix_appointments_patient_id");

                    b.HasIndex("RecommendationId")
                        .HasDatabaseName("ix_appointments_recommendation_id");

                    b.ToTable("appointments", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.AppointmentDiagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer")
                        .HasColumnName("appointment_id");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("DiagnosisId")
                        .HasColumnType("integer")
                        .HasColumnName("diagnosis_id");

                    b.Property<int>("Result")
                        .HasColumnType("integer")
                        .HasColumnName("result");

                    b.HasKey("Id")
                        .HasName("pk_appointment_diagnoses");

                    b.HasIndex("AppointmentId")
                        .HasDatabaseName("ix_appointment_diagnoses_appointment_id");

                    b.HasIndex("DiagnosisId")
                        .HasDatabaseName("ix_appointment_diagnoses_diagnosis_id");

                    b.ToTable("appointment_diagnoses", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.AppointmentFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer")
                        .HasColumnName("appointment_id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<int>("Discount")
                        .HasColumnType("integer")
                        .HasColumnName("discount");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric")
                        .HasColumnName("sum");

                    b.HasKey("Id")
                        .HasName("pk_appointment_facilities");

                    b.HasIndex("AppointmentId")
                        .HasDatabaseName("ix_appointment_facilities_appointment_id");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_appointment_facilities_facility_id");

                    b.ToTable("appointment_facilities", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.ClinicSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval")
                        .HasColumnName("end_time");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean")
                        .HasColumnName("is_actual");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval")
                        .HasColumnName("start_time");

                    b.HasKey("Id")
                        .HasName("pk_clinic_schedules");

                    b.ToTable("clinic_schedules", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_diagnoses");

                    b.ToTable("diagnoses", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric")
                        .HasColumnName("cost");

                    b.Property<int>("FacilityCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_category_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ValueAddedTaxId")
                        .HasColumnType("integer")
                        .HasColumnName("value_added_tax_id");

                    b.HasKey("Id")
                        .HasName("pk_facilities");

                    b.HasIndex("FacilityCategoryId")
                        .HasDatabaseName("ix_facilities_facility_category_id");

                    b.HasIndex("ValueAddedTaxId")
                        .HasDatabaseName("ix_facilities_value_added_tax_id");

                    b.ToTable("facilities", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.FacilityCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_facility_categories");

                    b.ToTable("facility_categories", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<int>("AnimalType")
                        .HasColumnType("integer")
                        .HasColumnName("animal_type");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_patients");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("ix_patients_client_id");

                    b.ToTable("patients", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer")
                        .HasColumnName("appointment_id");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer")
                        .HasColumnName("payment_type");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric")
                        .HasColumnName("sum");

                    b.HasKey("Id")
                        .HasName("pk_payments");

                    b.HasIndex("AppointmentId")
                        .HasDatabaseName("ix_payments_appointment_id");

                    b.ToTable("payments", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RecommendationsForCare")
                        .HasColumnType("text")
                        .HasColumnName("recommendations_for_care");

                    b.Property<string>("TreatmentPlan")
                        .HasColumnType("text")
                        .HasColumnName("treatment_plan");

                    b.HasKey("Id")
                        .HasName("pk_recommendations");

                    b.ToTable("recommendations", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<int>("RegistrationTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("registration_type_id");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_time");

                    b.HasKey("Id")
                        .HasName("pk_registrations");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("ix_registrations_client_id");

                    b.HasIndex("EmployeeId")
                        .HasDatabaseName("ix_registrations_employee_id");

                    b.HasIndex("RegistrationTypeId")
                        .HasDatabaseName("ix_registrations_registration_type_id");

                    b.ToTable("registrations", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.RegistrationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_registration_types");

                    b.ToTable("registration_types", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Vaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateRevaccination")
                        .HasColumnType("date")
                        .HasColumnName("date_revaccination");

                    b.Property<DateOnly>("DateVaccination")
                        .HasColumnType("date")
                        .HasColumnName("date_vaccination");

                    b.Property<int>("ExpirationTime")
                        .HasColumnType("integer")
                        .HasColumnName("expiration_time");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<string>("VaccineNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("vaccine_number");

                    b.HasKey("Id")
                        .HasName("pk_vaccinations");

                    b.HasIndex("PatientId")
                        .HasDatabaseName("ix_vaccinations_patient_id");

                    b.ToTable("vaccinations", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.ValueAddedTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Value")
                        .HasColumnType("integer")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_value_added_taxes");

                    b.ToTable("value_added_taxes", (string)null);
                });

            modelBuilder.Entity("SoVet.Data.Entities.Appointment", b =>
                {
                    b.HasOne("SoVet.Data.Entities.Employee", "Employee")
                        .WithMany("Appointments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_employees_employee_id");

                    b.HasOne("SoVet.Data.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_patients_patient_id");

                    b.HasOne("SoVet.Data.Entities.Recommendation", "Recommendation")
                        .WithMany("Appointments")
                        .HasForeignKey("RecommendationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_recommendations_recommendation_id");

                    b.Navigation("Employee");

                    b.Navigation("Patient");

                    b.Navigation("Recommendation");
                });

            modelBuilder.Entity("SoVet.Data.Entities.AppointmentDiagnosis", b =>
                {
                    b.HasOne("SoVet.Data.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentDiagnoses")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointment_diagnoses_appointments_appointment_id");

                    b.HasOne("SoVet.Data.Entities.Diagnosis", "Diagnosis")
                        .WithMany("AppointmentDiagnoses")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointment_diagnoses_diagnoses_diagnosis_id");

                    b.Navigation("Appointment");

                    b.Navigation("Diagnosis");
                });

            modelBuilder.Entity("SoVet.Data.Entities.AppointmentFacility", b =>
                {
                    b.HasOne("SoVet.Data.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentFacilities")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointment_facilities_appointments_appointment_id");

                    b.HasOne("SoVet.Data.Entities.Facility", "Facility")
                        .WithMany("AppointmentFacilities")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointment_facilities_facilities_facility_id");

                    b.Navigation("Appointment");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Facility", b =>
                {
                    b.HasOne("SoVet.Data.Entities.FacilityCategory", "FacilityCategory")
                        .WithMany("Facilities")
                        .HasForeignKey("FacilityCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_facilities_facility_categories_facility_category_id");

                    b.HasOne("SoVet.Data.Entities.ValueAddedTax", "ValueAddedTax")
                        .WithMany("Facilities")
                        .HasForeignKey("ValueAddedTaxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_facilities_value_added_taxes_value_added_tax_id");

                    b.Navigation("FacilityCategory");

                    b.Navigation("ValueAddedTax");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Patient", b =>
                {
                    b.HasOne("SoVet.Data.Entities.Client", "Owner")
                        .WithMany("Patients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_patients_clients_client_id");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Payment", b =>
                {
                    b.HasOne("SoVet.Data.Entities.Appointment", "Appointment")
                        .WithMany("Payments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payments_appointments_appointment_id");

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Registration", b =>
                {
                    b.HasOne("SoVet.Data.Entities.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_registrations_clients_client_id");

                    b.HasOne("SoVet.Data.Entities.Employee", "Employee")
                        .WithMany("Registrations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_registrations_employees_employee_id");

                    b.HasOne("SoVet.Data.Entities.RegistrationType", "RegistrationType")
                        .WithMany("Appointments")
                        .HasForeignKey("RegistrationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_registrations_registration_types_registration_type_id");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("RegistrationType");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Vaccination", b =>
                {
                    b.HasOne("SoVet.Data.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vaccinations_patients_patient_id");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Appointment", b =>
                {
                    b.Navigation("AppointmentDiagnoses");

                    b.Navigation("AppointmentFacilities");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Client", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Diagnosis", b =>
                {
                    b.Navigation("AppointmentDiagnoses");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Employee", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Facility", b =>
                {
                    b.Navigation("AppointmentFacilities");
                });

            modelBuilder.Entity("SoVet.Data.Entities.FacilityCategory", b =>
                {
                    b.Navigation("Facilities");
                });

            modelBuilder.Entity("SoVet.Data.Entities.Recommendation", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("SoVet.Data.Entities.RegistrationType", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("SoVet.Data.Entities.ValueAddedTax", b =>
                {
                    b.Navigation("Facilities");
                });
#pragma warning restore 612, 618
        }
    }
}
