.class public Lcom/igexin/push/extension/distribution/basic/i/c/ad;
.super Ljava/lang/Object;


# instance fields
.field private a:Lcom/igexin/push/extension/distribution/basic/i/c/dh;

.field private b:I

.field private c:Lcom/igexin/push/extension/distribution/basic/i/c/ac;


# direct methods
.method public constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/c/dh;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->b:I

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->a:Lcom/igexin/push/extension/distribution/basic/i/c/dh;

    return-void
.end method

.method public static b()Lcom/igexin/push/extension/distribution/basic/i/c/ad;
    .locals 2

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/b;

    invoke-direct {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;-><init>()V

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ad;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/dh;)V

    return-object v0
.end method


# virtual methods
.method public a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->a()Z

    move-result v0

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->b:I

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a(I)Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    move-result-object v0

    :goto_0
    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->c:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->a:Lcom/igexin/push/extension/distribution/basic/i/c/dh;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->c:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    invoke-virtual {v0, p1, p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    return-object v0

    :cond_0
    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->b()Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    move-result-object v0

    goto :goto_0
.end method

.method public a()Z
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->b:I

    if-lez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method
