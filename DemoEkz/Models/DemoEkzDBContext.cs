using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoEkz.models
{
    public partial class DemoEkzDBContext : DbContext
    {
        public DemoEkzDBContext()
        {
        }

        public DemoEkzDBContext(DbContextOptions<DemoEkzDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArticulSpecification> ArticulSpecifications { get; set; } = null!;
        public virtual DbSet<DecorCake> DecorCakes { get; set; } = null!;
        public virtual DbSet<DecorCakeSpecification> DecorCakeSpecifications { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<Ingridient> Ingridients { get; set; } = null!;
        public virtual DbSet<OperationSpecification> OperationSpecifications { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<SemiProductSpecification> SemiProductSpecifications { get; set; } = null!;
        public virtual DbSet<SystemUser> SystemUsers { get; set; } = null!;
        public virtual DbSet<TypeEquipment> TypeEquipments { get; set; } = null!;
        public virtual DbSet<UserOrder> UserOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=DemoEkzDB;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticulSpecification>(entity =>
            {
                entity.HasKey(e => new { e.ProductName, e.IngridientArticul })
                    .HasName("PK__ArticulS__DB8BC52C077B48E1");

                entity.ToTable("ArticulSpecification");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.IngridientArticul)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Ingridient_Articul");

                entity.Property(e => e.CountOperationSpecification).HasColumnName("Count_OperationSpecification");

                entity.HasOne(d => d.IngridientArticulNavigation)
                    .WithMany(p => p.ArticulSpecifications)
                    .HasForeignKey(d => d.IngridientArticul)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArticulSp__Ingri__5535A963");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.ArticulSpecifications)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArticulSp__Produ__5441852A");
            });

            modelBuilder.Entity<DecorCake>(entity =>
            {
                entity.HasKey(e => e.ArticulDecorCake)
                    .HasName("PK__DecorCak__14F2703667136A70");

                entity.ToTable("DecorCake");

                entity.Property(e => e.ArticulDecorCake)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Articul_DecorCake");

                entity.Property(e => e.BuyCostDecorCake)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BuyCost_DecorCake");

                entity.Property(e => e.CountDecorCake).HasColumnName("Count_DecorCake");

                entity.Property(e => e.ImageDecorCake).HasColumnName("Image_DecorCake");

                entity.Property(e => e.NameDecorCake)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_DecorCake");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Provider_Name");

                entity.Property(e => e.ShelfLife).HasColumnType("date");

                entity.Property(e => e.TypeNameDecorCake)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TypeName_DecorCake");

                entity.Property(e => e.UnitMeasurementsDecorCake)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("UnitMeasurements_DecorCake");

                entity.Property(e => e.WeightDecorCake)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Weight_DecorCake");

                entity.HasOne(d => d.ProviderNameNavigation)
                    .WithMany(p => p.DecorCakes)
                    .HasForeignKey(d => d.ProviderName)
                    .HasConstraintName("FK__DecorCake__Provi__4AB81AF0");
            });

            modelBuilder.Entity<DecorCakeSpecification>(entity =>
            {
                entity.HasKey(e => new { e.ProductName, e.DecorCakeArticul })
                    .HasName("PK__DecorCak__07B30944B20864D0");

                entity.ToTable("DecorCakeSpecification");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.DecorCakeArticul)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DecorCake_Articul");

                entity.Property(e => e.CountOperationSpecification).HasColumnName("Count_OperationSpecification");

                entity.HasOne(d => d.DecorCakeArticulNavigation)
                    .WithMany(p => p.DecorCakeSpecifications)
                    .HasForeignKey(d => d.DecorCakeArticul)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DecorCake__Decor__4E88ABD4");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.DecorCakeSpecifications)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DecorCake__Produ__4D94879B");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.NameEquipment)
                    .HasName("PK__Equipmen__4A902496E570EEBD");

                entity.Property(e => e.NameEquipment)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_Equipment");

                entity.Property(e => e.AcquisitionDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.DegreeOfWear)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionEquipment)
                    .IsUnicode(false)
                    .HasColumnName("Description_Equipment");

                entity.Property(e => e.TypeEquipmentName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TypeEquipment_Name");

                entity.HasOne(d => d.TypeEquipmentNameNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.TypeEquipmentName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Descr__3E52440B");
            });

            modelBuilder.Entity<Ingridient>(entity =>
            {
                entity.HasKey(e => e.ArticulIngridient)
                    .HasName("PK__Ingridie__A896910D6688DB0E");

                entity.ToTable("Ingridient");

                entity.Property(e => e.ArticulIngridient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Articul_Ingridient");

                entity.Property(e => e.BuyCostIngridient)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BuyCost_Ingridient");

                entity.Property(e => e.CountIngridient).HasColumnName("Count_Ingridient");

                entity.Property(e => e.DescriptionIngridient)
                    .IsUnicode(false)
                    .HasColumnName("Description_Ingridient");

                entity.Property(e => e.GostIngridient)
                    .IsUnicode(false)
                    .HasColumnName("GOST_Ingridient");

                entity.Property(e => e.ImageIngridient).HasColumnName("Image_Ingridient");

                entity.Property(e => e.NameIngridient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_Ingridient");

                entity.Property(e => e.PackingIngridient)
                    .IsUnicode(false)
                    .HasColumnName("Packing_Ingridient");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Provider_Name");

                entity.Property(e => e.ShelfLife).HasColumnType("date");

                entity.Property(e => e.TypeNameIngridient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TypeName_Ingridient");

                entity.Property(e => e.UnitMeasurementsIngridient)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("UnitMeasurements_Ingridient");

                entity.HasOne(d => d.ProviderNameNavigation)
                    .WithMany(p => p.Ingridients)
                    .HasForeignKey(d => d.ProviderName)
                    .HasConstraintName("FK__Ingridien__Provi__5165187F");
            });

            modelBuilder.Entity<OperationSpecification>(entity =>
            {
                entity.HasKey(e => new { e.ProductName, e.NameOperationSpecification, e.NumberOperationSpecification })
                    .HasName("PK__Operatio__632CCDEC414FB518");

                entity.ToTable("OperationSpecification");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.NameOperationSpecification)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_OperationSpecification");

                entity.Property(e => e.NumberOperationSpecification).HasColumnName("Number_OperationSpecification");

                entity.Property(e => e.EquipmentName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Equipment_Name");

                entity.Property(e => e.QuantitySemiProductSpecification).HasColumnName("Quantity_SemiProductSpecification");

                entity.HasOne(d => d.EquipmentNameNavigation)
                    .WithMany(p => p.OperationSpecifications)
                    .HasForeignKey(d => d.EquipmentName)
                    .HasConstraintName("FK__Operation__Equip__4222D4EF");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.OperationSpecifications)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Operation__Produ__412EB0B6");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.NameProduct)
                    .HasName("PK__Product__0F1728904AE6AB81");

                entity.ToTable("Product");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_Product");

                entity.Property(e => e.SizeProduct).HasColumnName("Size_Product");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.NameProvider)
                    .HasName("PK__Provider__4441E4A5998A1895");

                entity.ToTable("Provider");

                entity.Property(e => e.NameProvider)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_Provider");

                entity.Property(e => e.AddresProvider)
                    .IsUnicode(false)
                    .HasColumnName("Addres_Provider");

                entity.Property(e => e.DeliveryPeriodProvider).HasColumnName("DeliveryPeriod_Provider");
            });

            modelBuilder.Entity<SemiProductSpecification>(entity =>
            {
                entity.HasKey(e => new { e.ProductName, e.SemiProductName })
                    .HasName("PK__SemiProd__E3F5B100E57CA862");

                entity.ToTable("SemiProductSpecification");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.SemiProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SemiProduct_Name");

                entity.Property(e => e.CountOperationSpecification).HasColumnName("Count_OperationSpecification");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.SemiProductSpecificationProductNameNavigations)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SemiProdu__Produ__44FF419A");

                entity.HasOne(d => d.SemiProductNameNavigation)
                    .WithMany(p => p.SemiProductSpecificationSemiProductNameNavigations)
                    .HasForeignKey(d => d.SemiProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SemiProdu__SemiP__45F365D3");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => new { e.LoginSystemUser, e.PasswordSystemUser })
                    .HasName("PK__SystemUs__913011DC4DA76F51");

                entity.ToTable("SystemUser");

                entity.Property(e => e.LoginSystemUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Login_SystemUser");

                entity.Property(e => e.PasswordSystemUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Password_SystemUser");

                entity.Property(e => e.LastnameSystemUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Lastname_SystemUser");

                entity.Property(e => e.NameRoleSystemUser)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NameRole_SystemUser");

                entity.Property(e => e.NameSystemUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_SystemUser");

                entity.Property(e => e.PhotoSystemUser).HasColumnName("Photo_SystemUser");

                entity.Property(e => e.PhotoTypeSystemUser)
                    .HasMaxLength(10)
                    .HasColumnName("PhotoType_SystemUser");

                entity.Property(e => e.SurenameSystemUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Surename_SystemUser");
            });

            modelBuilder.Entity<TypeEquipment>(entity =>
            {
                entity.HasKey(e => e.NameTypeEquipment)
                    .HasName("PK__TypeEqui__7100DC583C1F8AD5");

                entity.ToTable("TypeEquipment");

                entity.Property(e => e.NameTypeEquipment)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_TypeEquipment");
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasKey(e => new { e.NumberUserOrder, e.DateUserOrder })
                    .HasName("PK__UserOrde__B2314F37981D8978");

                entity.ToTable("UserOrder");

                entity.Property(e => e.NumberUserOrder).HasColumnName("Number_UserOrder");

                entity.Property(e => e.DateUserOrder)
                    .HasColumnType("date")
                    .HasColumnName("Date_UserOrder")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CostUserOrder)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("Cost_UserOrder");

                entity.Property(e => e.DateFinishUserOrder)
                    .HasColumnType("date")
                    .HasColumnName("DateFinish_UserOrder");

                entity.Property(e => e.EmployeeSystemUserLogin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeSystemUser_Login");

                entity.Property(e => e.EmployeeSystemUserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeSystemUser_Password");

                entity.Property(e => e.ExampleUserOrder).HasColumnName("Example_UserOrder");

                entity.Property(e => e.NameUserOrder)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_UserOrder");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.SystemUserLogin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SystemUser_Login");

                entity.Property(e => e.SystemUserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SystemUser_Password");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOrder__Produ__5AEE82B9");

                entity.HasOne(d => d.EmployeeSystemUser)
                    .WithMany(p => p.UserOrderEmployeeSystemUsers)
                    .HasForeignKey(d => new { d.EmployeeSystemUserLogin, d.EmployeeSystemUserPassword })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOrder__59FA5E80");

                entity.HasOne(d => d.SystemUser)
                    .WithMany(p => p.UserOrderSystemUsers)
                    .HasForeignKey(d => new { d.SystemUserLogin, d.SystemUserPassword })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOrder__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
