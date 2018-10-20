.class public Lcom/igexin/push/core/b/f;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/push/core/b/a;


# static fields
.field private static final a:Ljava/lang/String;

.field private static b:Lcom/igexin/push/core/b/f;


# instance fields
.field private c:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private d:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const-class v0, Lcom/igexin/push/core/b/f;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Ljava/util/TreeMap;

    invoke-direct {v0}, Ljava/util/TreeMap;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/core/b/f;->c:Ljava/util/Map;

    return-void
.end method

.method public static a()Lcom/igexin/push/core/b/f;
    .locals 1

    sget-object v0, Lcom/igexin/push/core/b/f;->b:Lcom/igexin/push/core/b/f;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/core/b/f;

    invoke-direct {v0}, Lcom/igexin/push/core/b/f;-><init>()V

    sput-object v0, Lcom/igexin/push/core/b/f;->b:Lcom/igexin/push/core/b/f;

    :cond_0
    sget-object v0, Lcom/igexin/push/core/b/f;->b:Lcom/igexin/push/core/b/f;

    return-object v0
.end method

.method private a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V
    .locals 3

    new-instance v0, Landroid/content/ContentValues;

    invoke-direct {v0}, Landroid/content/ContentValues;-><init>()V

    const-string v1, "id"

    invoke-static {p2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Integer;)V

    const-string v1, "value"

    invoke-virtual {v0, v1, p3}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "runtime"

    const/4 v2, 0x0

    invoke-virtual {p1, v1, v2, v0}, Landroid/database/sqlite/SQLiteDatabase;->replace(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)J

    return-void
.end method

.method private a(Landroid/database/sqlite/SQLiteDatabase;I[B)V
    .locals 3

    new-instance v0, Landroid/content/ContentValues;

    invoke-direct {v0}, Landroid/content/ContentValues;-><init>()V

    const-string v1, "id"

    invoke-static {p2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Integer;)V

    const-string v1, "value"

    invoke-virtual {v0, v1, p3}, Landroid/content/ContentValues;->put(Ljava/lang/String;[B)V

    const-string v1, "runtime"

    const/4 v2, 0x0

    invoke-virtual {p1, v1, v2, v0}, Landroid/database/sqlite/SQLiteDatabase;->replace(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)J

    return-void
.end method

.method static synthetic a(Lcom/igexin/push/core/b/f;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/core/b/f;->f()V

    return-void
.end method

.method static synthetic a(Lcom/igexin/push/core/b/f;Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V
    .locals 0

    invoke-direct {p0, p1, p2, p3}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    return-void
.end method

.method static synthetic a(Lcom/igexin/push/core/b/f;Landroid/database/sqlite/SQLiteDatabase;I[B)V
    .locals 0

    invoke-direct {p0, p1, p2, p3}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    return-void
.end method

.method private a(Landroid/database/sqlite/SQLiteDatabase;I)[B
    .locals 5

    const/4 v0, 0x0

    :try_start_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "select value from runtime where id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    invoke-virtual {p1, v1, v2}, Landroid/database/sqlite/SQLiteDatabase;->rawQuery(Ljava/lang/String;[Ljava/lang/String;)Landroid/database/Cursor;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result-object v1

    if-eqz v1, :cond_1

    :try_start_1
    invoke-interface {v1}, Landroid/database/Cursor;->moveToFirst()Z

    move-result v2

    if-eqz v2, :cond_1

    const-string v2, "value"

    invoke-interface {v1, v2}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v2

    invoke-interface {v1, v2}, Landroid/database/Cursor;->getBlob(I)[B

    move-result-object v2

    sget-object v3, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v2, v3}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    move-result-object v0

    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    :cond_0
    :goto_0
    return-object v0

    :cond_1
    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    goto :goto_0

    :catch_0
    move-exception v1

    move-object v1, v0

    :goto_1
    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    goto :goto_0

    :catchall_0
    move-exception v1

    move-object v4, v1

    move-object v1, v0

    move-object v0, v4

    :goto_2
    if-eqz v1, :cond_2

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    :cond_2
    throw v0

    :catchall_1
    move-exception v0

    goto :goto_2

    :catch_1
    move-exception v2

    goto :goto_1
.end method

.method static synthetic a(Lcom/igexin/push/core/b/f;Ljava/lang/String;)[B
    .locals 1

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->f(Ljava/lang/String;)[B

    move-result-object v0

    return-object v0
.end method

.method private b(Landroid/database/sqlite/SQLiteDatabase;I)Ljava/lang/String;
    .locals 4

    const/4 v0, 0x0

    :try_start_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "select value from runtime where id="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    invoke-virtual {p1, v1, v2}, Landroid/database/sqlite/SQLiteDatabase;->rawQuery(Ljava/lang/String;[Ljava/lang/String;)Landroid/database/Cursor;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result-object v1

    if-eqz v1, :cond_1

    :try_start_1
    invoke-interface {v1}, Landroid/database/Cursor;->moveToFirst()Z

    move-result v2

    if-eqz v2, :cond_1

    const-string v2, "value"

    invoke-interface {v1, v2}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v2

    invoke-interface {v1, v2}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    move-result-object v0

    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    :cond_0
    :goto_0
    return-object v0

    :cond_1
    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    goto :goto_0

    :catch_0
    move-exception v1

    move-object v1, v0

    :goto_1
    if-eqz v1, :cond_0

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    goto :goto_0

    :catchall_0
    move-exception v1

    move-object v3, v1

    move-object v1, v0

    move-object v0, v3

    :goto_2
    if-eqz v1, :cond_2

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    :cond_2
    throw v0

    :catchall_1
    move-exception v0

    goto :goto_2

    :catch_1
    move-exception v2

    goto :goto_1
.end method

.method private e(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 5

    const/4 v0, 0x0

    :try_start_0
    const-string v1, "select value from runtime where id=25"

    const/4 v2, 0x0

    invoke-virtual {p1, v1, v2}, Landroid/database/sqlite/SQLiteDatabase;->rawQuery(Ljava/lang/String;[Ljava/lang/String;)Landroid/database/Cursor;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result-object v0

    if-eqz v0, :cond_0

    :try_start_1
    invoke-interface {v0}, Landroid/database/Cursor;->moveToFirst()Z

    move-result v1

    if-eqz v1, :cond_0

    new-instance v1, Ljava/lang/String;

    const-string v2, "value"

    invoke-interface {v0, v2}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v2

    invoke-interface {v0, v2}, Landroid/database/Cursor;->getBlob(I)[B

    move-result-object v2

    sget-object v3, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v3}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/b/b/a;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v1, Lcom/igexin/push/core/g;->B:Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    :cond_0
    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroid/database/Cursor;->close()V

    :cond_1
    :goto_0
    sget-object v0, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    if-nez v0, :cond_2

    sget-object v0, Lcom/igexin/push/core/g;->t:Ljava/lang/String;

    if-nez v0, :cond_4

    const-string v0, "cantgetimei"

    :goto_1
    invoke-static {v0}, Lcom/igexin/b/b/a;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    :cond_2
    return-void

    :catch_0
    move-exception v1

    if-eqz v0, :cond_1

    invoke-interface {v0}, Landroid/database/Cursor;->close()V

    goto :goto_0

    :catchall_0
    move-exception v1

    move-object v4, v1

    move-object v1, v0

    move-object v0, v4

    :goto_2
    if-eqz v1, :cond_3

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    :cond_3
    throw v0

    :cond_4
    sget-object v0, Lcom/igexin/push/core/g;->t:Ljava/lang/String;

    goto :goto_1

    :catchall_1
    move-exception v1

    move-object v4, v1

    move-object v1, v0

    move-object v0, v4

    goto :goto_2
.end method

.method private e()Z
    .locals 4

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/w;

    invoke-direct {v1, p0}, Lcom/igexin/push/core/b/w;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    return v0
.end method

.method private f()V
    .locals 2

    invoke-static {}, Lcom/igexin/push/util/e;->a()V

    invoke-static {}, Lcom/igexin/push/util/e;->c()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    const/4 v1, 0x5

    if-gt v0, v1, :cond_1

    :cond_0
    invoke-static {}, Lcom/igexin/push/util/e;->e()V

    :cond_1
    return-void
.end method

.method private f(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 2

    const/4 v0, 0x2

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/core/b/f;->b(Landroid/database/sqlite/SQLiteDatabase;I)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_1

    const-string v1, "null"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 v0, 0x0

    :cond_0
    sput-object v0, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    :cond_1
    return-void
.end method

.method private f(Ljava/lang/String;)[B
    .locals 1

    invoke-virtual {p1}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v0

    return-object v0
.end method

.method private g()Ljava/lang/String;
    .locals 6

    const-string v1, ""

    new-instance v2, Ljava/util/Random;

    new-instance v0, Ljava/util/Random;

    invoke-direct {v0}, Ljava/util/Random;-><init>()V

    invoke-virtual {v0}, Ljava/util/Random;->nextLong()J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Math;->abs(J)J

    move-result-wide v4

    invoke-direct {v2, v4, v5}, Ljava/util/Random;-><init>(J)V

    const/4 v0, 0x0

    :goto_0
    const/16 v3, 0xf

    if-ge v0, v3, :cond_0

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const/16 v3, 0xa

    invoke-virtual {v2, v3}, Ljava/util/Random;->nextInt(I)I

    move-result v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-object v1
.end method

.method private g(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 2

    const/16 v0, 0x2e

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/core/b/f;->b(Landroid/database/sqlite/SQLiteDatabase;I)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_1

    const-string v1, "null"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 v0, 0x0

    :cond_0
    sput-object v0, Lcom/igexin/push/core/g;->y:Ljava/lang/String;

    :cond_1
    return-void
.end method

.method private h(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 2

    const/16 v0, 0x30

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/core/b/f;->b(Landroid/database/sqlite/SQLiteDatabase;I)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_1

    const-string v1, "null"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 v0, 0x0

    :cond_0
    sput-object v0, Lcom/igexin/push/core/g;->z:Ljava/lang/String;

    :cond_1
    return-void
.end method

.method private i(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 2

    const/4 v0, 0x3

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/core/b/f;->b(Landroid/database/sqlite/SQLiteDatabase;I)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_1

    const-string v1, "null"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 v0, 0x0

    :cond_0
    sput-object v0, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    :cond_1
    return-void
.end method

.method private j(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 4

    const/4 v0, 0x1

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I)[B

    move-result-object v0

    if-eqz v0, :cond_0

    :try_start_0
    new-instance v1, Ljava/lang/String;

    invoke-direct {v1, v0}, Ljava/lang/String;-><init>([B)V

    const-string v0, "null"

    invoke-virtual {v1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    const-wide/16 v0, 0x0

    :goto_0
    sput-wide v0, Lcom/igexin/push/core/g;->q:J
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_1
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|db version changed, save session = "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-wide v2, Lcom/igexin/push/core/g;->q:J

    invoke-virtual {v0, v2, v3}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    :cond_0
    return-void

    :cond_1
    :try_start_1
    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    move-result-wide v0

    goto :goto_0

    :catch_0
    move-exception v0

    goto :goto_1
.end method

.method private k(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 3

    const/16 v0, 0x14

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I)[B

    move-result-object v1

    if-eqz v1, :cond_1

    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v1}, Ljava/lang/String;-><init>([B)V

    const-string v1, "null"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    const/4 v0, 0x0

    :cond_0
    sput-object v0, Lcom/igexin/push/core/g;->s:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v2, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "|db version changed, save cid = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    :cond_1
    return-void
.end method


# virtual methods
.method public a(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 0

    return-void
.end method

.method public a(I)Z
    .locals 4

    sput p1, Lcom/igexin/push/core/g;->S:I

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/n;

    invoke-direct {v1, p0}, Lcom/igexin/push/core/b/n;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    return v0
.end method

.method public a(J)Z
    .locals 5

    const/4 v0, 0x0

    sget-wide v2, Lcom/igexin/push/core/g;->G:J

    cmp-long v1, p1, v2

    if-eqz v1, :cond_0

    sput-wide p1, Lcom/igexin/push/core/g;->G:J

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/r;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/r;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    :cond_0
    return v0
.end method

.method public a(Ljava/lang/String;)Z
    .locals 4

    const/4 v0, 0x0

    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-eqz v1, :cond_0

    :goto_0
    return v0

    :cond_0
    sput-object p1, Lcom/igexin/push/core/g;->w:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/x;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/x;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    goto :goto_0
.end method

.method public a(Ljava/lang/String;Ljava/lang/String;J)Z
    .locals 1

    sput-wide p3, Lcom/igexin/push/core/g;->q:J

    sget-object v0, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_0

    sput-object p2, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    :cond_0
    sput-object p1, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-direct {p0}, Lcom/igexin/push/core/b/f;->e()Z

    move-result v0

    return v0
.end method

.method public a(Ljava/lang/String;Z)Z
    .locals 4

    const/4 v0, 0x0

    const/4 v3, 0x1

    const/4 v1, 0x0

    if-nez p1, :cond_0

    move v0, v1

    :goto_0
    return v0

    :cond_0
    if-eqz p2, :cond_2

    sget-object v2, Lcom/igexin/push/core/g;->aw:Ljava/lang/String;

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_4

    const-string v2, "null"

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1

    :goto_1
    sput-object v0, Lcom/igexin/push/core/g;->aw:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v2, Lcom/igexin/push/core/b/o;

    invoke-direct {v2, p0, p1}, Lcom/igexin/push/core/b/o;-><init>(Lcom/igexin/push/core/b/f;Ljava/lang/String;)V

    invoke-virtual {v0, v2, v1, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    goto :goto_0

    :cond_1
    move-object v0, p1

    goto :goto_1

    :cond_2
    sget-object v2, Lcom/igexin/push/core/g;->ax:Ljava/lang/String;

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_4

    const-string v2, "null"

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_3

    :goto_2
    sput-object v0, Lcom/igexin/push/core/g;->ax:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v2, Lcom/igexin/push/core/b/p;

    invoke-direct {v2, p0, p1}, Lcom/igexin/push/core/b/p;-><init>(Lcom/igexin/push/core/b/f;Ljava/lang/String;)V

    invoke-virtual {v0, v2, v1, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    goto :goto_0

    :cond_3
    move-object v0, p1

    goto :goto_2

    :cond_4
    move v0, v1

    goto :goto_0
.end method

.method public a(Z)Z
    .locals 4

    const/4 v0, 0x0

    sget-boolean v1, Lcom/igexin/push/core/g;->N:Z

    if-eq v1, p1, :cond_0

    sput-boolean p1, Lcom/igexin/push/core/g;->N:Z

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/k;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/k;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    :cond_0
    return v0
.end method

.method public b()V
    .locals 4

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/g;

    invoke-direct {v1, p0}, Lcom/igexin/push/core/b/g;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    return-void
.end method

.method public b(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 11

    const/16 v9, 0x14

    const/4 v8, 0x1

    const/4 v3, 0x0

    const-wide/16 v6, 0x0

    const/4 v1, 0x0

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->e(Landroid/database/sqlite/SQLiteDatabase;)V

    :try_start_0
    const-string v0, "select id, value from runtime order by id"

    const/4 v2, 0x0

    invoke-virtual {p1, v0, v2}, Landroid/database/sqlite/SQLiteDatabase;->rawQuery(Ljava/lang/String;[Ljava/lang/String;)Landroid/database/Cursor;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    move-result-object v0

    if-eqz v0, :cond_30

    :cond_0
    :goto_0
    :try_start_1
    invoke-interface {v0}, Landroid/database/Cursor;->moveToNext()Z

    move-result v2

    if-eqz v2, :cond_30

    const/4 v2, 0x0

    const/4 v4, 0x1

    invoke-interface {v0, v2}, Landroid/database/Cursor;->getInt(I)I

    move-result v5

    if-eq v5, v8, :cond_1

    const/16 v2, 0xe

    if-eq v5, v2, :cond_1

    const/16 v2, 0x13

    if-eq v5, v2, :cond_1

    if-eq v5, v9, :cond_1

    const/16 v2, 0x17

    if-eq v5, v2, :cond_1

    const/16 v2, 0x19

    if-eq v5, v2, :cond_1

    const/16 v2, 0x16

    if-eq v5, v2, :cond_1

    const/16 v2, 0x1f

    if-eq v5, v2, :cond_1

    const/16 v2, 0x1e

    if-ne v5, v2, :cond_15

    :cond_1
    invoke-interface {v0, v4}, Landroid/database/Cursor;->getBlob(I)[B

    move-result-object v2

    move-object v4, v2

    move-object v2, v1

    :goto_1
    if-nez v4, :cond_2

    if-eqz v2, :cond_0

    :cond_2
    packed-switch v5, :pswitch_data_0

    :pswitch_0
    goto :goto_0

    :pswitch_1
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    :try_start_2
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_16

    move-wide v4, v6

    :goto_2
    sput-wide v4, Lcom/igexin/push/core/g;->q:J
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    goto :goto_0

    :catch_0
    move-exception v2

    const-wide/16 v4, 0x0

    :try_start_3
    sput-wide v4, Lcom/igexin/push/core/g;->q:J
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_1
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    goto :goto_0

    :catch_1
    move-exception v2

    :goto_3
    if-eqz v0, :cond_3

    invoke-interface {v0}, Landroid/database/Cursor;->close()V

    :cond_3
    :goto_4
    sget-wide v4, Lcom/igexin/push/core/g;->q:J

    cmp-long v0, v4, v6

    if-nez v0, :cond_4

    invoke-static {}, Lcom/igexin/push/util/e;->d()J

    move-result-wide v4

    cmp-long v0, v4, v6

    if-eqz v0, :cond_4

    sput-wide v4, Lcom/igexin/push/core/g;->q:J

    invoke-static {v4, v5}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v0

    invoke-direct {p0, p1, v8, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    :cond_4
    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    if-nez v0, :cond_5

    invoke-static {}, Lcom/igexin/push/util/e;->b()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_5

    sput-object v0, Lcom/igexin/push/core/g;->s:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v0

    invoke-direct {p0, p1, v9, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    :cond_5
    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    if-nez v0, :cond_6

    sget-wide v4, Lcom/igexin/push/core/g;->q:J

    cmp-long v0, v4, v6

    if-eqz v0, :cond_6

    sget-wide v4, Lcom/igexin/push/core/g;->q:J

    invoke-static {v4, v5}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/b/a;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/core/g;->s:Ljava/lang/String;

    sget-wide v4, Lcom/igexin/push/core/g;->q:J

    invoke-static {v4, v5}, Lcom/igexin/push/core/g;->a(J)V

    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v0

    invoke-direct {p0, p1, v9, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    :cond_6
    const-string v0, "cfcd208495d565ef66e7dff9f98764da"

    sget-object v2, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_7

    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    if-eqz v0, :cond_8

    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    const-string v2, "([a-f]|[0-9]){32}"

    invoke-virtual {v0, v2}, Ljava/lang/String;->matches(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_8

    :cond_7
    sget-wide v4, Lcom/igexin/push/core/g;->q:J

    cmp-long v0, v4, v6

    if-eqz v0, :cond_31

    invoke-static {}, Lcom/igexin/push/core/b/f;->a()Lcom/igexin/push/core/b/f;

    move-result-object v0

    sget-wide v4, Lcom/igexin/push/core/g;->q:J

    invoke-virtual {v0, v4, v5}, Lcom/igexin/push/core/b/f;->b(J)Z

    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/core/g;->s:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/push/util/e;->f()V

    :cond_8
    :goto_5
    sget-object v0, Lcom/igexin/push/core/g;->ar:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_9

    const-string v0, "null"

    sget-object v1, Lcom/igexin/push/core/g;->ar:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_a

    :cond_9
    const/16 v0, 0x20

    invoke-static {v0}, Lcom/igexin/b/b/a;->a(I)Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/core/g;->ar:Ljava/lang/String;

    const/16 v0, 0xe

    sget-object v1, Lcom/igexin/push/core/g;->ar:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    :cond_a
    invoke-static {}, Lcom/igexin/push/util/e;->c()Ljava/lang/String;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    if-nez v1, :cond_b

    if-eqz v0, :cond_b

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v1

    const/4 v2, 0x5

    if-le v1, v2, :cond_b

    sput-object v0, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    const/4 v0, 0x2

    sget-object v1, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    :cond_b
    sget-object v0, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    if-nez v0, :cond_d

    sget-object v0, Lcom/igexin/push/core/g;->t:Ljava/lang/String;

    if-nez v0, :cond_c

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "V"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-direct {p0}, Lcom/igexin/push/core/b/f;->g()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    :cond_c
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "A-"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "-"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-virtual {v0, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    const/4 v0, 0x3

    sget-object v1, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    :cond_d
    iget-boolean v0, p0, Lcom/igexin/push/core/b/f;->d:Z

    if-eqz v0, :cond_14

    iput-boolean v3, p0, Lcom/igexin/push/core/b/f;->d:Z

    sget-object v0, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_e

    const/16 v0, 0x19

    sget-object v1, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/igexin/b/a/a/a;->d([BLjava/lang/String;)[B

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    :cond_e
    sget-wide v0, Lcom/igexin/push/core/g;->q:J

    cmp-long v0, v0, v6

    if-eqz v0, :cond_f

    sget-wide v0, Lcom/igexin/push/core/g;->q:J

    invoke-static {v0, v1}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v0

    invoke-direct {p0, p1, v8, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    :cond_f
    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_10

    sget-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v0

    invoke-direct {p0, p1, v9, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    :cond_10
    sget-object v0, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_11

    sget-object v0, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    const/4 v1, 0x5

    if-le v0, v1, :cond_11

    const/4 v0, 0x2

    sget-object v1, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    :cond_11
    sget-object v0, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_12

    const/4 v0, 0x3

    sget-object v1, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    :cond_12
    sget-object v0, Lcom/igexin/push/core/g;->y:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_13

    const/16 v0, 0x2e

    sget-object v1, Lcom/igexin/push/core/g;->y:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    :cond_13
    sget-object v0, Lcom/igexin/push/core/g;->z:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_14

    const/16 v0, 0x30

    sget-object v1, Lcom/igexin/push/core/g;->z:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    :cond_14
    return-void

    :cond_15
    :try_start_4
    invoke-interface {v0, v4}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;
    :try_end_4
    .catch Ljava/lang/Exception; {:try_start_4 .. :try_end_4} :catch_1
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    move-result-object v2

    move-object v4, v1

    goto/16 :goto_1

    :cond_16
    :try_start_5
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_0
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    move-result-wide v4

    goto/16 :goto_2

    :pswitch_2
    :try_start_6
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_17

    invoke-static {v2}, Ljava/lang/Boolean;->parseBoolean(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_19

    :cond_17
    move v2, v8

    :goto_6
    sput-boolean v2, Lcom/igexin/push/core/g;->k:Z
    :try_end_6
    .catch Ljava/lang/Exception; {:try_start_6 .. :try_end_6} :catch_1
    .catchall {:try_start_6 .. :try_end_6} :catchall_0

    goto/16 :goto_0

    :catchall_0
    move-exception v1

    move-object v10, v1

    move-object v1, v0

    move-object v0, v10

    :goto_7
    if-eqz v1, :cond_18

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    :cond_18
    throw v0

    :cond_19
    move v2, v3

    goto :goto_6

    :pswitch_3
    :try_start_7
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1a

    move-object v2, v1

    :cond_1a
    sput-object v2, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_4
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1b

    move-object v2, v1

    :cond_1b
    sput-object v2, Lcom/igexin/push/core/g;->y:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_5
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1c

    move-object v2, v1

    :cond_1c
    sput-object v2, Lcom/igexin/push/core/g;->z:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_6
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1d

    move-wide v4, v6

    :goto_8
    sput-wide v4, Lcom/igexin/push/core/g;->G:J

    goto/16 :goto_0

    :cond_1d
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v4

    goto :goto_8

    :pswitch_7
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1e

    move-wide v4, v6

    :goto_9
    sput-wide v4, Lcom/igexin/push/core/g;->F:J

    goto/16 :goto_0

    :cond_1e
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v4

    goto :goto_9

    :pswitch_8
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1f

    move-object v2, v1

    :cond_1f
    sput-object v2, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_9
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_20

    move-wide v4, v6

    :goto_a
    sput-wide v4, Lcom/igexin/push/core/g;->J:J

    goto/16 :goto_0

    :cond_20
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v4

    goto :goto_a

    :pswitch_a
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_21

    move-wide v4, v6

    :goto_b
    sput-wide v4, Lcom/igexin/push/core/g;->K:J

    goto/16 :goto_0

    :cond_21
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v4

    goto :goto_b

    :pswitch_b
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_22

    move-object v2, v1

    :cond_22
    sput-object v2, Lcom/igexin/push/core/g;->M:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_c
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V

    sput-object v2, Lcom/igexin/push/core/g;->ar:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_d
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V

    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_23

    move-object v2, v1

    :cond_23
    sput-object v2, Lcom/igexin/push/core/g;->w:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_e
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V

    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_24

    move-object v2, v1

    :cond_24
    sput-object v2, Lcom/igexin/push/core/g;->s:Ljava/lang/String;

    sput-object v2, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_f
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    invoke-static {v2}, Ljava/lang/Boolean;->parseBoolean(Ljava/lang/String;)Z

    move-result v2

    sput-boolean v2, Lcom/igexin/push/core/g;->N:Z

    goto/16 :goto_0

    :pswitch_10
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_25

    move-wide v4, v6

    :goto_c
    sput-wide v4, Lcom/igexin/push/core/g;->O:J

    goto/16 :goto_0

    :cond_25
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v4

    goto :goto_c

    :pswitch_11
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_26

    move-object v2, v1

    :cond_26
    sput-object v2, Lcom/igexin/push/core/g;->Q:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_12
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_27

    move v2, v3

    :goto_d
    sput v2, Lcom/igexin/push/core/g;->S:I

    goto/16 :goto_0

    :cond_27
    invoke-static {v2}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v2

    goto :goto_d

    :pswitch_13
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_28

    move-wide v4, v6

    :goto_e
    sput-wide v4, Lcom/igexin/push/core/g;->at:J

    goto/16 :goto_0

    :cond_28
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v4

    goto :goto_e

    :pswitch_14
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V

    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_29

    move-object v2, v1

    :cond_29
    sput-object v2, Lcom/igexin/push/core/g;->av:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v4, "|read last detectWifiLastResult = "

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    sget-object v4, Lcom/igexin/push/core/g;->av:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto/16 :goto_0

    :pswitch_15
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V

    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2a

    move-object v2, v1

    :cond_2a
    sput-object v2, Lcom/igexin/push/core/g;->au:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v4, "|read last detectMobileLastResult = "

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    sget-object v4, Lcom/igexin/push/core/g;->au:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto/16 :goto_0

    :pswitch_16
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V

    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2b

    move-object v2, v1

    :cond_2b
    sput-object v2, Lcom/igexin/push/core/g;->ax:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v4, "|read last domainWifiStatus = "

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    sget-object v4, Lcom/igexin/push/core/g;->ax:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto/16 :goto_0

    :pswitch_17
    new-instance v2, Ljava/lang/String;

    sget-object v5, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v4, v5}, Lcom/igexin/b/a/a/a;->c([BLjava/lang/String;)[B

    move-result-object v4

    invoke-direct {v2, v4}, Ljava/lang/String;-><init>([B)V

    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2c

    move-object v2, v1

    :cond_2c
    sput-object v2, Lcom/igexin/push/core/g;->aw:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v4, "|read last domainMobileStatus = "

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    sget-object v4, Lcom/igexin/push/core/g;->aw:Ljava/lang/String;

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto/16 :goto_0

    :pswitch_18
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2d

    move-wide v4, v6

    :goto_f
    sput-wide v4, Lcom/igexin/push/core/g;->L:J

    goto/16 :goto_0

    :cond_2d
    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v4

    goto :goto_f

    :pswitch_19
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2e

    move v2, v3

    :goto_10
    invoke-static {}, Lcom/igexin/push/d/b;->a()Lcom/igexin/push/d/b;

    move-result-object v4

    invoke-virtual {v4, v2}, Lcom/igexin/push/d/b;->a(Z)V

    goto/16 :goto_0

    :cond_2e
    invoke-static {v2}, Ljava/lang/Boolean;->parseBoolean(Ljava/lang/String;)Z

    move-result v2

    goto :goto_10

    :pswitch_1a
    const-string v4, "null"

    invoke-virtual {v2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2f

    move v2, v3

    :goto_11
    sput v2, Lcom/igexin/push/core/g;->az:I

    goto/16 :goto_0

    :cond_2f
    invoke-static {v2}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I
    :try_end_7
    .catch Ljava/lang/Exception; {:try_start_7 .. :try_end_7} :catch_1
    .catchall {:try_start_7 .. :try_end_7} :catchall_0

    move-result v2

    goto :goto_11

    :cond_30
    if-eqz v0, :cond_3

    invoke-interface {v0}, Landroid/database/Cursor;->close()V

    goto/16 :goto_4

    :cond_31
    sput-object v1, Lcom/igexin/push/core/g;->s:Ljava/lang/String;

    const-string v0, "null"

    sput-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    sput-wide v6, Lcom/igexin/push/core/g;->q:J

    goto/16 :goto_5

    :catchall_1
    move-exception v0

    goto/16 :goto_7

    :catch_2
    move-exception v0

    move-object v0, v1

    goto/16 :goto_3

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_1
        :pswitch_3
        :pswitch_8
        :pswitch_2
        :pswitch_0
        :pswitch_7
        :pswitch_0
        :pswitch_6
        :pswitch_0
        :pswitch_0
        :pswitch_9
        :pswitch_a
        :pswitch_b
        :pswitch_c
        :pswitch_f
        :pswitch_10
        :pswitch_11
        :pswitch_12
        :pswitch_d
        :pswitch_e
        :pswitch_13
        :pswitch_14
        :pswitch_15
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_16
        :pswitch_17
        :pswitch_18
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_19
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_4
        :pswitch_1a
        :pswitch_5
    .end packed-switch
.end method

.method public b(I)Z
    .locals 4

    const/4 v0, 0x0

    sget v1, Lcom/igexin/push/core/g;->az:I

    if-eq v1, p1, :cond_0

    sput p1, Lcom/igexin/push/core/g;->az:I

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/u;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/u;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    :cond_0
    return v0
.end method

.method public b(J)Z
    .locals 5

    invoke-static {p1, p2}, Lcom/igexin/push/core/g;->a(J)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/y;

    invoke-direct {v1, p0}, Lcom/igexin/push/core/b/y;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    return v0
.end method

.method public b(Ljava/lang/String;)Z
    .locals 4

    sput-object p1, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/z;

    invoke-direct {v1, p0}, Lcom/igexin/push/core/b/z;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    return v0
.end method

.method public b(Ljava/lang/String;Z)Z
    .locals 4

    const/4 v0, 0x0

    const/4 v3, 0x1

    const/4 v1, 0x0

    if-nez p1, :cond_0

    move v0, v1

    :goto_0
    return v0

    :cond_0
    if-eqz p2, :cond_2

    sget-object v2, Lcom/igexin/push/core/g;->au:Ljava/lang/String;

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_4

    const-string v2, "null"

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1

    :goto_1
    sput-object v0, Lcom/igexin/push/core/g;->au:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v2, Lcom/igexin/push/core/b/q;

    invoke-direct {v2, p0, p1}, Lcom/igexin/push/core/b/q;-><init>(Lcom/igexin/push/core/b/f;Ljava/lang/String;)V

    invoke-virtual {v0, v2, v1, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    goto :goto_0

    :cond_1
    move-object v0, p1

    goto :goto_1

    :cond_2
    sget-object v2, Lcom/igexin/push/core/g;->av:Ljava/lang/String;

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_4

    const-string v2, "null"

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_3

    :goto_2
    sput-object v0, Lcom/igexin/push/core/g;->av:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v2, Lcom/igexin/push/core/b/s;

    invoke-direct {v2, p0, p1}, Lcom/igexin/push/core/b/s;-><init>(Lcom/igexin/push/core/b/f;Ljava/lang/String;)V

    invoke-virtual {v0, v2, v1, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    goto :goto_0

    :cond_3
    move-object v0, p1

    goto :goto_2

    :cond_4
    move v0, v1

    goto :goto_0
.end method

.method public b(Z)Z
    .locals 4

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/v;

    invoke-direct {v1, p0, p1}, Lcom/igexin/push/core/b/v;-><init>(Lcom/igexin/push/core/b/f;Z)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    return v0
.end method

.method public c(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 4

    sget-wide v0, Lcom/igexin/push/core/g;->q:J

    invoke-static {v0, v1}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    sget-object v1, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/igexin/b/a/a/a;->d([BLjava/lang/String;)[B

    move-result-object v0

    const/4 v1, 0x1

    invoke-direct {p0, p1, v1, v0}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    const/4 v0, 0x4

    sget-boolean v1, Lcom/igexin/push/core/g;->k:Z

    invoke-static {v1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/16 v0, 0x8

    sget-wide v2, Lcom/igexin/push/core/g;->G:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/4 v0, 0x6

    sget-wide v2, Lcom/igexin/push/core/g;->F:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/16 v0, 0x20

    sget-wide v2, Lcom/igexin/push/core/g;->L:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/4 v0, 0x3

    sget-object v1, Lcom/igexin/push/core/g;->A:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/16 v0, 0xb

    sget-wide v2, Lcom/igexin/push/core/g;->J:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/16 v0, 0xc

    sget-wide v2, Lcom/igexin/push/core/g;->K:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/16 v0, 0x14

    sget-object v1, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    sget-object v2, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-static {v1, v2}, Lcom/igexin/b/a/a/a;->d([BLjava/lang/String;)[B

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    const/4 v0, 0x2

    sget-object v1, Lcom/igexin/push/core/g;->x:Ljava/lang/String;

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;ILjava/lang/String;)V

    const/16 v0, 0x19

    sget-object v1, Lcom/igexin/push/core/g;->B:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    sget-object v2, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/igexin/b/a/a/a;->d([BLjava/lang/String;)[B

    move-result-object v1

    invoke-direct {p0, p1, v0, v1}, Lcom/igexin/push/core/b/f;->a(Landroid/database/sqlite/SQLiteDatabase;I[B)V

    return-void
.end method

.method public c()Z
    .locals 2

    const-wide/16 v0, 0x0

    sput-wide v0, Lcom/igexin/push/core/g;->q:J

    const-string v0, "null"

    sput-object v0, Lcom/igexin/push/core/g;->r:Ljava/lang/String;

    invoke-direct {p0}, Lcom/igexin/push/core/b/f;->e()Z

    move-result v0

    return v0
.end method

.method public c(J)Z
    .locals 5

    const/4 v0, 0x1

    const/4 v1, 0x0

    sget-wide v2, Lcom/igexin/push/core/g;->K:J

    cmp-long v2, v2, p1

    if-eqz v2, :cond_0

    sput-wide p1, Lcom/igexin/push/core/g;->K:J

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v2

    new-instance v3, Lcom/igexin/push/core/b/ab;

    invoke-direct {v3, p0}, Lcom/igexin/push/core/b/ab;-><init>(Lcom/igexin/push/core/b/f;)V

    invoke-virtual {v2, v3, v1, v0}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    :goto_0
    return v0

    :cond_0
    move v0, v1

    goto :goto_0
.end method

.method public c(Ljava/lang/String;)Z
    .locals 4

    sput-object p1, Lcom/igexin/push/core/g;->z:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/aa;

    invoke-direct {v1, p0}, Lcom/igexin/push/core/b/aa;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    return v0
.end method

.method public d()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/core/b/f;->c:Ljava/util/Map;

    return-object v0
.end method

.method public d(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/core/b/f;->d:Z

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->e(Landroid/database/sqlite/SQLiteDatabase;)V

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->j(Landroid/database/sqlite/SQLiteDatabase;)V

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->k(Landroid/database/sqlite/SQLiteDatabase;)V

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->i(Landroid/database/sqlite/SQLiteDatabase;)V

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->f(Landroid/database/sqlite/SQLiteDatabase;)V

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->g(Landroid/database/sqlite/SQLiteDatabase;)V

    invoke-direct {p0, p1}, Lcom/igexin/push/core/b/f;->h(Landroid/database/sqlite/SQLiteDatabase;)V

    return-void
.end method

.method public d(J)Z
    .locals 5

    sput-wide p1, Lcom/igexin/push/core/g;->at:J

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v1, Lcom/igexin/push/core/b/f;->a:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "|save idc config failed time : "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/core/b/h;

    invoke-direct {v1, p0, p1, p2}, Lcom/igexin/push/core/b/h;-><init>(Lcom/igexin/push/core/b/f;J)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    return v0
.end method

.method public d(Ljava/lang/String;)Z
    .locals 4

    const/4 v0, 0x1

    const/4 v1, 0x0

    if-eqz p1, :cond_0

    sget-object v2, Lcom/igexin/push/core/g;->M:Ljava/lang/String;

    invoke-virtual {p1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_0

    sput-object p1, Lcom/igexin/push/core/g;->M:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v2

    new-instance v3, Lcom/igexin/push/core/b/j;

    invoke-direct {v3, p0}, Lcom/igexin/push/core/b/j;-><init>(Lcom/igexin/push/core/b/f;)V

    invoke-virtual {v2, v3, v1, v0}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    :goto_0
    return v0

    :cond_0
    move v0, v1

    goto :goto_0
.end method

.method public e(J)Z
    .locals 5

    const/4 v0, 0x0

    sget-wide v2, Lcom/igexin/push/core/g;->J:J

    cmp-long v1, v2, p1

    if-eqz v1, :cond_0

    sput-wide p1, Lcom/igexin/push/core/g;->J:J

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/i;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/i;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    :cond_0
    return v0
.end method

.method public e(Ljava/lang/String;)Z
    .locals 4

    const/4 v0, 0x0

    sget-object v1, Lcom/igexin/push/core/g;->Q:Ljava/lang/String;

    invoke-virtual {p1, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    sput-object p1, Lcom/igexin/push/core/g;->Q:Ljava/lang/String;

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/m;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/m;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    :cond_0
    return v0
.end method

.method public f(J)Z
    .locals 5

    const/4 v0, 0x0

    sget-wide v2, Lcom/igexin/push/core/g;->O:J

    cmp-long v1, v2, p1

    if-eqz v1, :cond_0

    sput-wide p1, Lcom/igexin/push/core/g;->O:J

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/l;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/l;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    :cond_0
    return v0
.end method

.method public g(J)Z
    .locals 5

    const/4 v0, 0x0

    sget-wide v2, Lcom/igexin/push/core/g;->L:J

    cmp-long v1, v2, p1

    if-eqz v1, :cond_0

    sput-wide p1, Lcom/igexin/push/core/g;->L:J

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/core/b/t;

    invoke-direct {v2, p0}, Lcom/igexin/push/core/b/t;-><init>(Lcom/igexin/push/core/b/f;)V

    const/4 v3, 0x1

    invoke-virtual {v1, v2, v0, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    move-result v0

    :cond_0
    return v0
.end method
