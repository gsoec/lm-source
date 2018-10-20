.class public Lcom/igexin/push/extension/distribution/gbd/h/a/k;
.super Lcom/igexin/push/extension/distribution/gbd/h/b;


# static fields
.field private static c:Lcom/igexin/push/extension/distribution/gbd/h/a/k;


# direct methods
.method private constructor <init>()V
    .locals 4

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/h/b;-><init>()V

    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ae:J

    const-wide/16 v2, 0x3e8

    mul-long/2addr v0, v2

    iput-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/h/a/k;->b:J

    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->y:J

    iput-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/h/a/k;->a:J

    return-void
.end method

.method public static d()Lcom/igexin/push/extension/distribution/gbd/h/a/k;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/k;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/k;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/gbd/h/a/k;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/gbd/h/a/k;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/k;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/k;

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/k;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/k;

    return-object v0
.end method


# virtual methods
.method public a()V
    .locals 4

    :try_start_0
    const-string v0, "GBD_UST"

    const-string v1, "dotask ..."

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/extension/distribution/gbd/f/a;

    new-instance v2, Lcom/igexin/push/extension/distribution/gbd/f/a/d;

    invoke-direct {v2}, Lcom/igexin/push/extension/distribution/gbd/f/a/d;-><init>()V

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/gbd/f/a;-><init>(Lcom/igexin/push/extension/distribution/gbd/f/d;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method public a(J)V
    .locals 1

    iput-wide p1, p0, Lcom/igexin/push/extension/distribution/gbd/h/a/k;->a:J

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a()Lcom/igexin/push/extension/distribution/gbd/e/a/e;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->f(J)V

    return-void
.end method

.method public c()Z
    .locals 1

    const/4 v0, 0x1

    return v0
.end method
