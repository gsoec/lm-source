.class public Lcom/igexin/push/extension/distribution/basic/i/b/i;
.super Lcom/igexin/push/extension/distribution/basic/i/b/l;


# instance fields
.field private f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

.field private g:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;)V
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;-><init>()V

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V

    return-void
.end method

.method public constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/c/ae;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V
    .locals 0

    invoke-direct {p0, p2, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/l;-><init>(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    return-void
.end method

.method private static a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Ljava/util/List;)Ljava/lang/Integer;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<E:",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            ">(",
            "Lcom/igexin/push/extension/distribution/basic/i/b/i;",
            "Ljava/util/List",
            "<TE;>;)",
            "Ljava/lang/Integer;"
        }
    .end annotation

    invoke-static {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    if-ge v1, v0, :cond_1

    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    :goto_1
    return-object v0

    :cond_0
    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_1
    const/4 v0, 0x0

    goto :goto_1
.end method

.method private static a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Ljava/lang/StringBuilder;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a()Ljava/lang/String;

    move-result-object v0

    const-string v1, "br"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->b(Ljava/lang/StringBuilder;)Z

    move-result v0

    if-nez v0, :cond_0

    const-string v0, " "

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :cond_0
    return-void
.end method

.method private a(Ljava/lang/StringBuilder;Lcom/igexin/push/extension/distribution/basic/i/b/o;)V
    .locals 2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->s()Z

    move-result v1

    if-nez v1, :cond_0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->b(Ljava/lang/StringBuilder;)Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->b(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    :cond_0
    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method private b(Ljava/lang/StringBuilder;)V
    .locals 3

    invoke-static {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Ljava/lang/StringBuilder;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    instance-of v2, v0, Lcom/igexin/push/extension/distribution/basic/i/b/o;

    if-eqz v2, :cond_1

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/o;

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Ljava/lang/StringBuilder;Lcom/igexin/push/extension/distribution/basic/i/b/o;)V

    goto :goto_0

    :cond_1
    instance-of v2, v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-eqz v2, :cond_0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->length()I

    move-result v2

    if-lez v2, :cond_2

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->j()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->b(Ljava/lang/StringBuilder;)Z

    move-result v2

    if-nez v2, :cond_2

    const-string v2, " "

    invoke-virtual {p1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :cond_2
    invoke-direct {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b(Ljava/lang/StringBuilder;)V

    goto :goto_0

    :cond_3
    return-void
.end method

.method private c(Ljava/lang/StringBuilder;)V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    instance-of v2, v0, Lcom/igexin/push/extension/distribution/basic/i/b/o;

    if-eqz v2, :cond_1

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/o;

    invoke-direct {p0, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Ljava/lang/StringBuilder;Lcom/igexin/push/extension/distribution/basic/i/b/o;)V

    goto :goto_0

    :cond_1
    instance-of v2, v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-eqz v2, :cond_0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-static {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Ljava/lang/StringBuilder;)V

    goto :goto_0

    :cond_2
    return-void
.end method

.method private d(Ljava/lang/StringBuilder;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    invoke-virtual {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a(Ljava/lang/StringBuilder;)V

    goto :goto_0

    :cond_0
    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 2

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    const/4 v0, 0x1

    new-array v0, v0, [Lcom/igexin/push/extension/distribution/basic/i/b/l;

    const/4 v1, 0x0

    aput-object p1, v0, v1

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a([Lcom/igexin/push/extension/distribution/basic/i/b/l;)V

    return-object p0
.end method

.method public a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 0

    invoke-super {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/l;

    return-object p0
.end method

.method public a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/f;
    .locals 1

    invoke-static {p1, p0}, Lcom/igexin/push/extension/distribution/basic/i/d/af;->a(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v0

    return-object v0
.end method

.method public a()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method a(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 2

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    if-lez v0, :cond_1

    invoke-virtual {p3}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->d()Z

    move-result v0

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->c()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->c()Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    invoke-virtual {p0, p1, p2, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->c(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V

    :cond_1
    const-string v0, "<"

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->h()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v0, p1, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/StringBuilder;Lcom/igexin/push/extension/distribution/basic/i/b/f;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->d()Z

    move-result v0

    if-eqz v0, :cond_2

    const-string v0, " />"

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :goto_0
    return-void

    :cond_2
    const-string v0, ">"

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_0
.end method

.method public b(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 1

    invoke-super {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->c(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-object v0
.end method

.method public synthetic b(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    return-object v0
.end method

.method public b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/f;
    .locals 2

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;)V

    invoke-virtual {p1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/ab;

    invoke-direct {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ab;-><init>(Ljava/lang/String;)V

    invoke-static {v1, p0}, Lcom/igexin/push/extension/distribution/basic/i/d/a;->a(Lcom/igexin/push/extension/distribution/basic/i/d/g;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v0

    return-object v0
.end method

.method b(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->d()Z

    move-result v0

    if-nez v0, :cond_2

    :cond_0
    invoke-virtual {p3}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->d()Z

    move-result v0

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->c()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-virtual {p0, p1, p2, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->c(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V

    :cond_1
    const-string v0, "</"

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->h()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ">"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :cond_2
    return-void
.end method

.method public synthetic c(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    return-object v0
.end method

.method public c(Ljava/lang/String;)Z
    .locals 2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->u()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-virtual {p1, v0}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public synthetic clone()Ljava/lang/Object;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    return-object v0
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

.method public f()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 1

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->g()Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->u()Ljava/util/Set;

    return-object v0
.end method

.method public synthetic g()Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    return-object v0
.end method

.method public h()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->a()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->hashCode()I

    move-result v0

    mul-int/lit8 v1, v0, 0x1f

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->hashCode()I

    move-result v0

    :goto_0
    add-int/2addr v0, v1

    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public i()Lcom/igexin/push/extension/distribution/basic/i/c/ae;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    return-object v0
.end method

.method public j()Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->b()Z

    move-result v0

    return v0
.end method

.method public k()Ljava/lang/String;
    .locals 1

    const-string v0, "id"

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-nez v0, :cond_0

    const-string v0, ""

    :cond_0
    return-object v0
.end method

.method public final l()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    return-object v0
.end method

.method public m()Lcom/igexin/push/extension/distribution/basic/i/d/f;
    .locals 4

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :cond_0
    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/l;

    instance-of v3, v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-eqz v3, :cond_0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-interface {v1, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_1
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/f;

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/d/f;-><init>(Ljava/util/List;)V

    return-object v0
.end method

.method public n()Lcom/igexin/push/extension/distribution/basic/i/b/i;
    .locals 4

    const/4 v0, 0x0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    if-nez v1, :cond_1

    :cond_0
    :goto_0
    return-object v0

    :cond_1
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->m()Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v1

    invoke-static {p0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Ljava/util/List;)Ljava/lang/Integer;

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    invoke-virtual {v2}, Ljava/lang/Integer;->intValue()I

    move-result v3

    if-lez v3, :cond_0

    invoke-virtual {v2}, Ljava/lang/Integer;->intValue()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    invoke-interface {v1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_0
.end method

.method public o()Ljava/lang/Integer;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    :goto_0
    return-object v0

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->m()Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v0

    invoke-static {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Ljava/util/List;)Ljava/lang/Integer;

    move-result-object v0

    goto :goto_0
.end method

.method public p()Lcom/igexin/push/extension/distribution/basic/i/d/f;
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/h;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/h;-><init>()V

    invoke-static {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/d/a;->a(Lcom/igexin/push/extension/distribution/basic/i/d/g;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v0

    return-object v0
.end method

.method public q()Ljava/lang/String;
    .locals 1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->b(Ljava/lang/StringBuilder;)V

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public r()Ljava/lang/String;
    .locals 1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->c(Ljava/lang/StringBuilder;)V

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method s()Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->f()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->s()Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public t()Ljava/lang/String;
    .locals 1

    const-string v0, "class"

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d_()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public u()Ljava/util/Set;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Set",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->g:Ljava/util/Set;

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->t()Ljava/lang/String;

    move-result-object v0

    const-string v1, "\\s+"

    invoke-virtual {v0, v1}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    new-instance v1, Ljava/util/LinkedHashSet;

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    invoke-direct {v1, v0}, Ljava/util/LinkedHashSet;-><init>(Ljava/util/Collection;)V

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->g:Ljava/util/Set;

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/i;->g:Ljava/util/Set;

    return-object v0
.end method

.method public v()Ljava/lang/String;
    .locals 1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/StringBuilder;)V

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public synthetic w()Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->l()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    return-object v0
.end method
