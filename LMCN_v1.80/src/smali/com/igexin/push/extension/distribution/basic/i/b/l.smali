.class public abstract Lcom/igexin/push/extension/distribution/basic/i/b/l;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/lang/Cloneable;


# instance fields
.field a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

.field b:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/b/l;",
            ">;"
        }
    .end annotation
.end field

.field c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

.field d:Ljava/lang/String;

.field e:I


# direct methods
.method protected constructor <init>()V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    invoke-static {}, Ljava/util/Collections;->emptyList()Ljava/util/List;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    return-void
.end method

.method protected constructor <init>(Ljava/lang/String;)V
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;-><init>()V

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;-><init>(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V

    return-void
.end method

.method protected constructor <init>(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V
    .locals 2

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-static {p2}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    new-instance v0, Ljava/util/ArrayList;

    const/4 v1, 0x4

    invoke-direct {v0, v1}, Ljava/util/ArrayList;-><init>(I)V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-virtual {p1}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d:Ljava/lang/String;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    return-void
.end method

.method private a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V
    .locals 1

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-eqz v0, :cond_0

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    :cond_0
    invoke-virtual {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-void
.end method

.method private c()V
    .locals 2

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-ge v1, v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v0, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b(I)V

    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_0
    return-void
.end method

.method private d()Lcom/igexin/push/extension/distribution/basic/i/b/f;
    .locals 2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->z()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->z()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->d()Lcom/igexin/push/extension/distribution/basic/i/b/f;

    move-result-object v0

    :goto_0
    return-object v0

    :cond_0
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/e;

    const-string v1, ""

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/e;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->d()Lcom/igexin/push/extension/distribution/basic/i/b/f;

    move-result-object v0

    goto :goto_0
.end method


# virtual methods
.method public A()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-void
.end method

.method public B()Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 5

    const/4 v0, 0x0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-nez v1, :cond_1

    :cond_0
    :goto_0
    return-object v0

    :cond_1
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    iget-object v1, v1, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->C()I

    move-result v2

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v3

    invoke-virtual {v2}, Ljava/lang/Integer;->intValue()I

    move-result v4

    add-int/lit8 v4, v4, 0x1

    if-le v3, v4, :cond_0

    invoke-virtual {v2}, Ljava/lang/Integer;->intValue()I

    move-result v0

    add-int/lit8 v0, v0, 0x1

    invoke-interface {v1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    goto :goto_0
.end method

.method public C()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e:I

    return v0
.end method

.method public a(I)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    return-object v0
.end method

.method public a(Lcom/igexin/push/extension/distribution/basic/i/d/ad;)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/ac;

    invoke-direct {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/d/ac;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/ad;)V

    invoke-virtual {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ac;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-object p0
.end method

.method public abstract a()Ljava/lang/String;
.end method

.method protected varargs a(I[Lcom/igexin/push/extension/distribution/basic/i/b/l;)V
    .locals 3

    invoke-static {p2}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a([Ljava/lang/Object;)V

    array-length v0, p2

    add-int/lit8 v0, v0, -0x1

    :goto_0
    if-ltz v0, :cond_0

    aget-object v1, p2, v0

    invoke-direct {p0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v2, p1, v1}, Ljava/util/List;->add(ILjava/lang/Object;)V

    add-int/lit8 v0, v0, -0x1

    goto :goto_0

    :cond_0
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c()V

    return-void
.end method

.method protected a(Ljava/lang/StringBuilder;)V
    .locals 3

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/ac;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/b/n;

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d()Lcom/igexin/push/extension/distribution/basic/i/b/f;

    move-result-object v2

    invoke-direct {v1, p1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/n;-><init>(Ljava/lang/StringBuilder;Lcom/igexin/push/extension/distribution/basic/i/b/f;)V

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/d/ac;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/ad;)V

    invoke-virtual {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ac;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-void
.end method

.method abstract a(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
.end method

.method protected varargs a([Lcom/igexin/push/extension/distribution/basic/i/b/l;)V
    .locals 4

    array-length v1, p1

    const/4 v0, 0x0

    :goto_0
    if-ge v0, v1, :cond_0

    aget-object v2, p1, v0

    invoke-direct {p0, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v3, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v3}, Ljava/util/List;->size()I

    move-result v3

    add-int/lit8 v3, v3, -0x1

    invoke-virtual {v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b(I)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public b(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;Ljava/lang/String;)V

    return-object p0
.end method

.method protected b(I)V
    .locals 0

    iput p1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e:I

    return-void
.end method

.method abstract b(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
.end method

.method public c(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 4

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->C()I

    move-result v1

    const/4 v2, 0x1

    new-array v2, v2, [Lcom/igexin/push/extension/distribution/basic/i/b/l;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a(I[Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-object p0
.end method

.method protected c(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 2

    const-string v0, "\n"

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p3}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->e()I

    move-result v1

    mul-int/2addr v1, p2

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(I)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method public synthetic clone()Ljava/lang/Object;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->g()Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v0

    return-object v0
.end method

.method public d(Ljava/lang/String;)Ljava/lang/String;
    .locals 2

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    :goto_0
    return-object v0

    :cond_0
    invoke-virtual {p1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v0

    const-string v1, "abs:"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    const-string v0, "abs:"

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    invoke-virtual {p1, v0}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->g(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    :cond_1
    const-string v0, ""

    goto :goto_0
.end method

.method protected d(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    :cond_0
    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    return-void
.end method

.method public d_()Ljava/lang/String;
    .locals 2

    new-instance v0, Ljava/lang/StringBuilder;

    const/16 v1, 0x80

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(I)V

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a(Ljava/lang/StringBuilder;)V

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method protected e(Lcom/igexin/push/extension/distribution/basic/i/b/l;)V
    .locals 2

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-ne v0, p0, :cond_0

    const/4 v0, 0x1

    :goto_0
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Z)V

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->C()I

    move-result v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v1, v0}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c()V

    const/4 v0, 0x0

    iput-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    return-void

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public e(Ljava/lang/String;)Z
    .locals 2

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-virtual {p1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v0

    const-string v1, "abs:"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    const-string v0, "abs:"

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    invoke-virtual {p1, v0}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->b(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->g(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->b(Ljava/lang/String;)Z

    move-result v0

    goto :goto_0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 1

    if-ne p0, p1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method protected f(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 4

    :try_start_0
    invoke-super {p0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;
    :try_end_0
    .catch Ljava/lang/CloneNotSupportedException; {:try_start_0 .. :try_end_0} :catch_0

    iput-object p1, v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-nez p1, :cond_0

    const/4 v1, 0x0

    :goto_0
    iput v1, v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e:I

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->d()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v1

    :goto_1
    iput-object v1, v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d:Ljava/lang/String;

    iput-object v1, v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d:Ljava/lang/String;

    new-instance v1, Ljava/util/ArrayList;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v2

    invoke-direct {v1, v2}, Ljava/util/ArrayList;-><init>(I)V

    iput-object v1, v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_2
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_2

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    iget-object v3, v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->f(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v1

    invoke-interface {v3, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_2

    :catch_0
    move-exception v0

    new-instance v1, Ljava/lang/RuntimeException;

    invoke-direct {v1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw v1

    :cond_0
    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e:I

    goto :goto_0

    :cond_1
    const/4 v1, 0x0

    goto :goto_1

    :cond_2
    return-object v0
.end method

.method public f(Ljava/lang/String;)V
    .locals 1

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/m;

    invoke-direct {v0, p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/m;-><init>(Lcom/igexin/push/extension/distribution/basic/i/b/l;Ljava/lang/String;)V

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a(Lcom/igexin/push/extension/distribution/basic/i/d/ad;)Lcom/igexin/push/extension/distribution/basic/i/b/l;

    return-void
.end method

.method public g()Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    const/4 v0, 0x0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->f(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v0

    return-object v0
.end method

.method public g(Ljava/lang/String;)Ljava/lang/String;
    .locals 4

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;)V

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_0

    const-string v0, ""

    :goto_0
    return-object v0

    :cond_0
    :try_start_0
    new-instance v1, Ljava/net/URL;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d:Ljava/lang/String;

    invoke-direct {v1, v2}, Ljava/net/URL;-><init>(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/net/MalformedURLException; {:try_start_0 .. :try_end_0} :catch_0

    :try_start_1
    const-string v2, "?"

    invoke-virtual {v0, v2}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1}, Ljava/net/URL;->getPath()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    :cond_1
    new-instance v2, Ljava/net/URL;

    invoke-direct {v2, v1, v0}, Ljava/net/URL;-><init>(Ljava/net/URL;Ljava/lang/String;)V

    invoke-virtual {v2}, Ljava/net/URL;->toExternalForm()Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    :catch_0
    move-exception v1

    new-instance v1, Ljava/net/URL;

    invoke-direct {v1, v0}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/net/URL;->toExternalForm()Ljava/lang/String;
    :try_end_1
    .catch Ljava/net/MalformedURLException; {:try_start_1 .. :try_end_1} :catch_1

    move-result-object v0

    goto :goto_0

    :catch_1
    move-exception v0

    const-string v0, ""

    goto :goto_0
.end method

.method public hashCode()I
    .locals 3

    const/4 v1, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->hashCode()I

    move-result v0

    :goto_0
    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    if-eqz v2, :cond_0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->hashCode()I

    move-result v1

    :cond_0
    add-int/2addr v0, v1

    return v0

    :cond_1
    move v0, v1

    goto :goto_0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d_()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public w()Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    return-object v0
.end method

.method public x()Lcom/igexin/push/extension/distribution/basic/i/b/b;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    return-object v0
.end method

.method public y()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/b/l;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b:Ljava/util/List;

    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public z()Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 1

    instance-of v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;

    if-eqz v0, :cond_0

    check-cast p0, Lcom/igexin/push/extension/distribution/basic/i/b/e;

    :goto_0
    return-object p0

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-nez v0, :cond_1

    const/4 p0, 0x0

    goto :goto_0

    :cond_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->z()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object p0

    goto :goto_0
.end method
