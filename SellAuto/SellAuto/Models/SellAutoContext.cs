using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SellAuto.Models
{
    public partial class SellAutoContext : DbContext
    {
        public SellAutoContext()
        {
        }

        public SellAutoContext(DbContextOptions<SellAutoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ad { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<CarMark> CarMark { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Drive> Drive { get; set; }
        public virtual DbSet<Kpp> Kpp { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<SteeringWheel> SteeringWheel { get; set; }
        public virtual DbSet<Sub> Sub { get; set; }
        public virtual DbSet<TypeCarBody> TypeCarBody { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=Fremmy;Password=;Database=SellAuto");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.HasKey(e => e.IdAd)
                    .HasName("ad_pkey");

                entity.ToTable("ad");

                entity.HasComment("Объявление");

                entity.HasIndex(e => e.Vin)
                    .HasName("ad_vin_key")
                    .IsUnique();

                entity.Property(e => e.IdAd)
                    .HasColumnName("id_ad")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы ad");

                entity.Property(e => e.CarModelId)
                    .HasColumnName("car_model_id")
                    .HasComment("Внешний ключ таблицы car_model(Модель авто)");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasComment("Внешний ключ таблицы city");

                entity.Property(e => e.ColorId)
                    .HasColumnName("color_id")
                    .HasComment("Цвет");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .HasComment("Описание");

                entity.Property(e => e.DriveId)
                    .HasColumnName("drive_id")
                    .HasComment("Внешний ключ таблицы drive");

                entity.Property(e => e.KppId)
                    .HasColumnName("kpp_id")
                    .HasComment("Внешний ключ таблицы kpp");

                entity.Property(e => e.MarkId)
                    .HasColumnName("mark_id")
                    .HasComment("Внешний ключ таблицы mark");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnName("phone1")
                    .HasMaxLength(100)
                    .HasComment("Телефон 1");

                entity.Property(e => e.PhotoFile)
                    .HasColumnName("photo_file")
                    .HasMaxLength(255);

                entity.Property(e => e.Power)
                    .HasColumnName("power")
                    .HasComment("Мощность");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasComment("Стоимость авто");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasComment("Внешний ключ таблицы Status (Статус)");

                entity.Property(e => e.SteeringWheelId)
                    .HasColumnName("steering_wheel_id")
                    .HasComment("Внешний ключ таблицы steering_wheel");

                entity.Property(e => e.Sts)
                    .HasColumnName("sts")
                    .HasMaxLength(100)
                    .HasComment("СТС автомобиля");

                entity.Property(e => e.TypeCarBodyId)
                    .HasColumnName("type_car_body_id")
                    .HasComment("Внешний ключ таблицы type_car_body");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("Внешний ключ таблицы user");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasColumnName("vin")
                    .HasMaxLength(100)
                    .HasComment("VIN номер");

                entity.Property(e => e.Volume)
                    .HasColumnName("volume")
                    .HasComment("Объем");

                entity.Property(e => e.YearPublish)
                    .HasColumnName("year_publish")
                    .HasComment("Год выпуска авто");

                entity.HasOne(d => d.CarModel)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.CarModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ad_fk8");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ad_fk6");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("ad_fk5");

                entity.HasOne(d => d.Drive)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.DriveId)
                    .HasConstraintName("ad_fk3");

                entity.HasOne(d => d.Kpp)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.KppId)
                    .HasConstraintName("ad_fk4");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.MarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ad_fk");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("ad_fk9");

                entity.HasOne(d => d.SteeringWheel)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.SteeringWheelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ad_fk1");

                entity.HasOne(d => d.TypeCarBody)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.TypeCarBodyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ad_fk2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ad_fk7");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("area_pkey");

                entity.ToTable("area");

                entity.HasComment("Область");

                entity.HasIndex(e => e.Name)
                    .HasName("area_name_key")
                    .IsUnique();

                entity.Property(e => e.IdArea)
                    .HasColumnName("id_area")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы area(Область)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование области");
            });

            modelBuilder.Entity<CarMark>(entity =>
            {
                entity.HasKey(e => e.IdMark)
                    .HasName("mark_pkey");

                entity.ToTable("car_mark");

                entity.HasComment("Марка автомобиля");

                entity.HasIndex(e => e.Name)
                    .HasName("mark_name_key")
                    .IsUnique();

                entity.Property(e => e.IdMark)
                    .HasColumnName("id_mark")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы mark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование марки");
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.IdModel)
                    .HasName("model_pkey");

                entity.ToTable("car_model");

                entity.HasComment("Модель автомобиля");

                entity.Property(e => e.IdModel)
                    .HasColumnName("id_model")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы model");

                entity.Property(e => e.MarkId)
                    .HasColumnName("mark_id")
                    .HasComment("Внешний ключ таблицы mark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование модели");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.CarModel)
                    .HasForeignKey(d => d.MarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("model_fk");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("city_pkey");

                entity.ToTable("city");

                entity.HasComment("Город");

                entity.HasIndex(e => e.Name)
                    .HasName("city_name_key")
                    .IsUnique();

                entity.Property(e => e.IdCity)
                    .HasColumnName("id_city")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы city(Город)");

                entity.Property(e => e.AreaId)
                    .HasColumnName("area_id")
                    .HasComment("Внешний ключ таблицы area (Область)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование города");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_fk");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("Color_pkey");

                entity.ToTable("color");

                entity.HasComment("Цвет");

                entity.HasIndex(e => e.Name)
                    .HasName("Color_Name_key")
                    .IsUnique();

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_сolor")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы Mark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование цвета");
            });

            modelBuilder.Entity<Drive>(entity =>
            {
                entity.HasKey(e => e.IdDrive)
                    .HasName("drive_pkey");

                entity.ToTable("drive");

                entity.HasComment("Привод");

                entity.HasIndex(e => e.Name)
                    .HasName("drive_name_key")
                    .IsUnique();

                entity.Property(e => e.IdDrive)
                    .HasColumnName("id_drive")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы drive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование привода");
            });

            modelBuilder.Entity<Kpp>(entity =>
            {
                entity.HasKey(e => e.IdKpp)
                    .HasName("kpp_pkey");

                entity.ToTable("kpp");

                entity.HasComment("Коробка передач (КПП)");

                entity.HasIndex(e => e.Name)
                    .HasName("kpp_name_key")
                    .IsUnique();

                entity.Property(e => e.IdKpp)
                    .HasColumnName("id_kpp")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы kpp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование КПП");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.IdPhoto)
                    .HasName("photo_pkey");

                entity.ToTable("photo");

                entity.HasComment("Фото");

                entity.Property(e => e.IdPhoto)
                    .HasColumnName("id_photo")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы photo(Фото)");

                entity.Property(e => e.AdId)
                    .HasColumnName("ad_id")
                    .HasColumnType("character varying")
                    .HasComment("Внешний ключ таблицы ad(Объявление)");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file")
                    .HasMaxLength(255)
                    .HasComment("Фотография");

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.AdId)
                    .HasConstraintName("photo_fk");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("status_pkey");

                entity.ToTable("status");

                entity.HasComment("Статус объявления");

                entity.HasIndex(e => e.Name)
                    .HasName("status_name_key")
                    .IsUnique();

                entity.Property(e => e.IdStatus)
                    .HasColumnName("id_status")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы status");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Название статуса");
            });

            modelBuilder.Entity<SteeringWheel>(entity =>
            {
                entity.HasKey(e => e.IdSteeringWheel)
                    .HasName("steering_wheel_pkey");

                entity.ToTable("steering_wheel");

                entity.HasComment("Руль");

                entity.HasIndex(e => e.Name)
                    .HasName("steering_wheel_name_key")
                    .IsUnique();

                entity.Property(e => e.IdSteeringWheel)
                    .HasColumnName("id_steering_wheel")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы steering_wheel");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование руля");
            });

            modelBuilder.Entity<Sub>(entity =>
            {
                entity.HasKey(e => e.IdSub)
                    .HasName("sub_pkey");

                entity.ToTable("sub");

                entity.HasComment("Подписка");

                entity.Property(e => e.IdSub)
                    .HasColumnName("id_sub")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы sub(Подписка)");

                entity.Property(e => e.AdId)
                    .IsRequired()
                    .HasColumnName("ad_id")
                    .HasColumnType("character varying")
                    .HasComment("Внешний ключ таблицы ad (Объявление)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("Внешний ключ таблицы user (Пользователь)");

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.Sub)
                    .HasForeignKey(d => d.AdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sub_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sub)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sub_fk1");
            });

            modelBuilder.Entity<TypeCarBody>(entity =>
            {
                entity.HasKey(e => e.IdTypeCarBody)
                    .HasName("type_car_body_pkey");

                entity.ToTable("type_car_body");

                entity.HasComment("Тип кузова");

                entity.HasIndex(e => e.Name)
                    .HasName("type_car_body_name_key")
                    .IsUnique();

                entity.Property(e => e.IdTypeCarBody)
                    .HasColumnName("id_type_car_body")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы type_car_body");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasComment("Наименование типа кузова");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("user_pkey");

                entity.ToTable("user");

                entity.HasComment("Пользователь");

                entity.HasIndex(e => e.Login)
                    .HasName("user_login_key")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid")
                    .HasComment("Уникальный идентификатор таблицы user(Пользователь)");

                entity.Property(e => e.Fio)
                    .HasColumnName("fio")
                    .HasMaxLength(100)
                    .HasComment("ФИО пользователя");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(100)
                    .HasComment("Логин пользователя");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .HasComment("Пароль пользователя");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(100)
                    .HasComment("Роль пользователя");

                entity.Property(e => e.UserPhoto)
                    .HasColumnName("userPhoto")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'./images/DefaultUser.png'::character varying")
                    .HasComment("Фотография пользователя");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
