.class Lcom/igexin/push/extension/distribution/basic/i/d/b;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/push/extension/distribution/basic/i/d/ad;


# instance fields
.field private final a:Lcom/igexin/push/extension/distribution/basic/i/b/i;

.field private final b:Lcom/igexin/push/extension/distribution/basic/i/d/f;

.field private final c:Lcom/igexin/push/extension/distribution/basic/i/d/g;


# direct methods
.method constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/d/f;Lcom/igexin/push/extension/distribution/basic/i/d/g;)V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/b;->a:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/b;->b:Lcom/igexin/push/extension/distribution/basic/i/d/f;

    iput-object p3, p0, Lcom/igexin/push/extension/distribution/basic/i/d/b;->c:Lcom/igexin/push/extension/distribution/basic/i/d/g;

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/l;I)V
    .locals 2

    instance-of v0, p1, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-eqz v0, :cond_0

    check-cast p1, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/b;->c:Lcom/igexin/push/extension/distribution/basic/i/d/g;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/b;->a:Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0, v1, p1}, Lcom/igexin/push/extension/distribution/basic/i/d/g;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/b;->b:Lcom/igexin/push/extension/distribution/basic/i/d/f;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    :cond_0
    return-void
.end method

.method public b(Lcom/igexin/push/extension/distribution/basic/i/b/l;I)V
    .locals 0

    return-void
.end method
