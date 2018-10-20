.class public Lcom/igexin/push/extension/distribution/basic/i/b/o;
.super Lcom/igexin/push/extension/distribution/basic/i/b/l;


# instance fields
.field f:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;-><init>()V

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->d:Ljava/lang/String;

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->f:Ljava/lang/String;

    return-void
.end method

.method static a(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    invoke-static {p0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->c(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static b(Ljava/lang/String;)Ljava/lang/String;
    .locals 2

    const-string v0, "^\\s+"

    const-string v1, ""

    invoke-virtual {p0, v0, v1}, Ljava/lang/String;->replaceFirst(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static b(Ljava/lang/StringBuilder;)Z
    .locals 2

    invoke-virtual {p0}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    invoke-virtual {p0, v0}, Ljava/lang/StringBuilder;->charAt(I)C

    move-result v0

    const/16 v1, 0x20

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private e()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "text"

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->f:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;Ljava/lang/String;)V

    :cond_0
    return-void
.end method


# virtual methods
.method public a()Ljava/lang/String;
    .locals 1

    const-string v0, "#text"

    return-object v0
.end method

.method a(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/f;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p3}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->d()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->w()Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v0

    instance-of v0, v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-eqz v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->w()Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->s()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    move-object v1, v0

    :cond_0
    invoke-virtual {p3}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->d()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->C()I

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    instance-of v0, v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->a:Lcom/igexin/push/extension/distribution/basic/i/b/l;

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ae;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ae;->c()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->d()Z

    move-result v0

    if-nez v0, :cond_1

    invoke-virtual {p0, p1, p2, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V

    :cond_1
    invoke-virtual {p1, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method public b(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/l;
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->e()V

    invoke-super {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/l;

    move-result-object v0

    return-object v0
.end method

.method b(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 0

    return-void
.end method

.method public c()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->f:Ljava/lang/String;

    :goto_0
    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "text"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method

.method public d(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->e()V

    invoke-super {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public d()Z
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->c()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public e(Ljava/lang/String;)Z
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->e()V

    invoke-super {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->e(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public g(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->e()V

    invoke-super {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->g(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->d_()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public x()Lcom/igexin/push/extension/distribution/basic/i/b/b;
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/o;->e()V

    invoke-super {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v0

    return-object v0
.end method
