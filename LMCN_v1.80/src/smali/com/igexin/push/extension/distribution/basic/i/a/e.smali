.class public Lcom/igexin/push/extension/distribution/basic/i/a/e;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/push/extension/distribution/basic/i/a;


# instance fields
.field private a:Lcom/igexin/push/extension/distribution/basic/i/e;

.field private b:Lcom/igexin/push/extension/distribution/basic/i/f;


# direct methods
.method private constructor <init>()V
    .locals 2

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/a/h;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/h;-><init>(Lcom/igexin/push/extension/distribution/basic/i/a/f;)V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->a:Lcom/igexin/push/extension/distribution/basic/i/e;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/a/i;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/i;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->b:Lcom/igexin/push/extension/distribution/basic/i/f;

    return-void
.end method

.method public static b(Ljava/net/URL;)Lcom/igexin/push/extension/distribution/basic/i/a;
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/a/e;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/e;-><init>()V

    invoke-interface {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/a;->a(Ljava/net/URL;)Lcom/igexin/push/extension/distribution/basic/i/a;

    return-object v0
.end method


# virtual methods
.method public a(I)Lcom/igexin/push/extension/distribution/basic/i/a;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->a:Lcom/igexin/push/extension/distribution/basic/i/e;

    invoke-interface {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/e;->a(I)Lcom/igexin/push/extension/distribution/basic/i/e;

    return-object p0
.end method

.method public a(Ljava/net/URL;)Lcom/igexin/push/extension/distribution/basic/i/a;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->a:Lcom/igexin/push/extension/distribution/basic/i/e;

    invoke-interface {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/e;->a(Ljava/net/URL;)Lcom/igexin/push/extension/distribution/basic/i/b;

    return-object p0
.end method

.method public a()Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->a:Lcom/igexin/push/extension/distribution/basic/i/e;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/d;->a:Lcom/igexin/push/extension/distribution/basic/i/d;

    invoke-interface {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/e;->a(Lcom/igexin/push/extension/distribution/basic/i/d;)Lcom/igexin/push/extension/distribution/basic/i/b;

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/e;->b()Lcom/igexin/push/extension/distribution/basic/i/f;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->b:Lcom/igexin/push/extension/distribution/basic/i/f;

    invoke-interface {v0}, Lcom/igexin/push/extension/distribution/basic/i/f;->e()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    return-object v0
.end method

.method public b()Lcom/igexin/push/extension/distribution/basic/i/f;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->a:Lcom/igexin/push/extension/distribution/basic/i/e;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/i;->a(Lcom/igexin/push/extension/distribution/basic/i/e;)Lcom/igexin/push/extension/distribution/basic/i/a/i;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->b:Lcom/igexin/push/extension/distribution/basic/i/f;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/a/e;->b:Lcom/igexin/push/extension/distribution/basic/i/f;

    return-object v0
.end method
