.class Lcom/igexin/push/core/b/x;
.super Lcom/igexin/push/b/d;


# instance fields
.field final synthetic a:Lcom/igexin/push/core/b/f;


# direct methods
.method constructor <init>(Lcom/igexin/push/core/b/f;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/core/b/x;->a:Lcom/igexin/push/core/b/f;

    invoke-direct {p0}, Lcom/igexin/push/b/d;-><init>()V

    return-void
.end method


# virtual methods
.method public a()V
    .locals 4

    invoke-static {}, Lcom/igexin/push/core/b/f;->a()Lcom/igexin/push/core/b/f;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/core/b/x;->c:Landroid/database/sqlite/SQLiteDatabase;

    const/16 v2, 0x13

    sget-object v3, Lcom/igexin/push/core/g;->w:Ljava/lang/String;

    invoke-virtual {v3}, Ljava/lang/String;->getBytes()[B

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/push/util/EncryptUtils;->getBytesEncrypted([B)[B

    move-result-object v3

    invoke-static {v0, v1, v2, v3}, Lcom/igexin/push/core/b/f;->a(Lcom/igexin/push/core/b/f;Landroid/database/sqlite/SQLiteDatabase;I[B)V

    return-void
.end method
