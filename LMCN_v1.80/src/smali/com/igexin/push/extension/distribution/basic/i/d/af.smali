.class public Lcom/igexin/push/extension/distribution/basic/i/d/af;
.super Ljava/lang/Object;


# instance fields
.field private final a:Lcom/igexin/push/extension/distribution/basic/i/d/g;

.field private final b:Lcom/igexin/push/extension/distribution/basic/i/b/i;


# direct methods
.method private constructor <init>(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-virtual {p1}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;)V

    invoke-static {p2}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/g;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/af;->a:Lcom/igexin/push/extension/distribution/basic/i/d/g;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/af;->b:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-void
.end method

.method private a()Lcom/igexin/push/extension/distribution/basic/i/d/f;
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/af;->a:Lcom/igexin/push/extension/distribution/basic/i/d/g;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/af;->b:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/d/a;->a(Lcom/igexin/push/extension/distribution/basic/i/d/g;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v0

    return-object v0
.end method

.method public static a(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/d/f;
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/af;

    invoke-direct {v0, p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/d/af;-><init>(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/af;->a()Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v0

    return-object v0
.end method
