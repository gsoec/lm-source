.class public Lcom/igexin/push/extension/distribution/gbd/h/a/h;
.super Lcom/igexin/push/extension/distribution/gbd/h/b;


# static fields
.field private static c:Lcom/igexin/push/extension/distribution/gbd/h/a/h;


# direct methods
.method private constructor <init>()V
    .locals 4

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/h/b;-><init>()V

    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    const-wide/16 v2, 0x3e8

    mul-long/2addr v0, v2

    iput-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/h/a/h;->b:J

    return-void
.end method

.method public static d()Lcom/igexin/push/extension/distribution/gbd/h/a/h;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/h;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/h;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/gbd/h/a/h;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/gbd/h/a/h;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/h;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/h;

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/h;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/h;

    return-object v0
.end method


# virtual methods
.method public a()V
    .locals 2

    const-string v0, "GBD_RT"

    const-string v1, "doTask"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->c:Lcom/igexin/push/extension/distribution/gbd/d/a;

    if-eqz v0, :cond_0

    invoke-static {}, Landroid/os/Message;->obtain()Landroid/os/Message;

    move-result-object v0

    const/4 v1, 0x2

    iput v1, v0, Landroid/os/Message;->what:I

    const/16 v1, 0x15

    iput v1, v0, Landroid/os/Message;->arg1:I

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/c;->c:Lcom/igexin/push/extension/distribution/gbd/d/a;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/gbd/d/a;->sendMessage(Landroid/os/Message;)Z

    :cond_0
    return-void
.end method

.method public c()Z
    .locals 1

    const/4 v0, 0x1

    return v0
.end method

.method public e()V
    .locals 4

    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    const-wide/16 v2, 0x3e8

    mul-long/2addr v0, v2

    iput-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/h/a/h;->b:J

    return-void
.end method
