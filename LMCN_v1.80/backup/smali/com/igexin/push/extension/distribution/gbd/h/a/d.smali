.class public Lcom/igexin/push/extension/distribution/gbd/h/a/d;
.super Lcom/igexin/push/extension/distribution/gbd/h/b;


# static fields
.field private static c:Lcom/igexin/push/extension/distribution/gbd/h/a/d;


# direct methods
.method private constructor <init>()V
    .locals 2

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/h/b;-><init>()V

    const-wide/32 v0, 0x5265c00

    iput-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/h/a/d;->b:J

    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->j:J

    iput-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/h/a/d;->a:J

    return-void
.end method

.method public static d()Lcom/igexin/push/extension/distribution/gbd/h/a/d;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/d;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/d;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/gbd/h/a/d;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/gbd/h/a/d;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/d;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/d;

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/h/a/d;->c:Lcom/igexin/push/extension/distribution/gbd/h/a/d;

    return-object v0
.end method


# virtual methods
.method public a()V
    .locals 4

    const-string v0, "GBD_GCT"

    const-string v1, "doTask GBD_CONFIG"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/extension/distribution/gbd/f/a;

    new-instance v2, Lcom/igexin/push/extension/distribution/gbd/f/a/c;

    invoke-direct {v2}, Lcom/igexin/push/extension/distribution/gbd/f/a/c;-><init>()V

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/gbd/f/a;-><init>(Lcom/igexin/push/extension/distribution/gbd/f/d;)V

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    return-void
.end method

.method public c()Z
    .locals 1

    const/4 v0, 0x1

    return v0
.end method
