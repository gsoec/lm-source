.class Lcom/igexin/push/core/a/f;
.super Lcom/igexin/push/f/a;


# instance fields
.field final synthetic a:Lcom/igexin/push/core/a/e;


# direct methods
.method constructor <init>(Lcom/igexin/push/core/a/e;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/core/a/f;->a:Lcom/igexin/push/core/a/e;

    invoke-direct {p0}, Lcom/igexin/push/f/a;-><init>()V

    return-void
.end method


# virtual methods
.method protected a()V
    .locals 3

    invoke-static {}, Lcom/igexin/sdk/GTServiceManager;->getInstance()Lcom/igexin/sdk/GTServiceManager;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/core/g;->f:Landroid/content/Context;

    invoke-virtual {v0, v1}, Lcom/igexin/sdk/GTServiceManager;->getUserPushService(Landroid/content/Context;)Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_1

    sget-object v1, Lcom/igexin/push/core/a;->n:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_1

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v0

    if-eqz v0, :cond_0

    sget-object v1, Lcom/igexin/push/core/g;->ac:Ljava/lang/String;

    const/4 v2, 0x0

    invoke-static {v0, v1, v2}, Lcom/igexin/push/util/e;->a([BLjava/lang/String;Z)V

    :cond_0
    :goto_0
    return-void

    :cond_1
    new-instance v0, Ljava/io/File;

    sget-object v1, Lcom/igexin/push/core/g;->ac:Ljava/lang/String;

    invoke-direct {v0, v1}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/io/File;->delete()Z

    move-result v0

    if-eqz v0, :cond_0

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "del "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    sget-object v1, Lcom/igexin/push/core/g;->ac:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, " success ~~~"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto :goto_0
.end method
