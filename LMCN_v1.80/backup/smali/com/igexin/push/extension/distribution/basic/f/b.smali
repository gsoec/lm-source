.class public Lcom/igexin/push/extension/distribution/basic/f/b;
.super Landroid/database/sqlite/SQLiteOpenHelper;


# instance fields
.field a:Landroid/database/sqlite/SQLiteDatabase;

.field private b:Z


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 3

    const/4 v2, 0x0

    const-string v0, "pushsdk.db"

    const/4 v1, 0x3

    invoke-direct {p0, p1, v0, v2, v1}, Landroid/database/sqlite/SQLiteOpenHelper;-><init>(Landroid/content/Context;Ljava/lang/String;Landroid/database/sqlite/SQLiteDatabase$CursorFactory;I)V

    iput-object v2, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->a:Landroid/database/sqlite/SQLiteDatabase;

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->b:Z

    return-void
.end method


# virtual methods
.method public a(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/f/b;->getWritableDatabase()Landroid/database/sqlite/SQLiteDatabase;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->a:Landroid/database/sqlite/SQLiteDatabase;

    :try_start_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->a:Landroid/database/sqlite/SQLiteDatabase;

    invoke-virtual {v0, p1, p2, p3}, Landroid/database/sqlite/SQLiteDatabase;->replace(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)J
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method public a()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->b:Z

    return v0
.end method

.method public onCreate(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 1

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->b:Z

    return-void
.end method

.method public onDowngrade(Landroid/database/sqlite/SQLiteDatabase;II)V
    .locals 1

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->b:Z

    return-void
.end method

.method public onUpgrade(Landroid/database/sqlite/SQLiteDatabase;II)V
    .locals 1

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/f/b;->b:Z

    return-void
.end method
