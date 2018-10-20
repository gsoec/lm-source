.class final Lcom/ta/utdid2/core/persistent/d$a;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/ta/utdid2/core/persistent/b;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/ta/utdid2/core/persistent/d;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "a"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/ta/utdid2/core/persistent/d$a$a;
    }
.end annotation


# static fields
.field private static final f:Ljava/lang/Object;


# instance fields
.field a:Ljava/util/Map;

.field b:Z

.field private final c:Ljava/io/File;

.field private final d:Ljava/io/File;

.field private final e:I

.field private g:Ljava/util/WeakHashMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/WeakHashMap",
            "<",
            "Lcom/ta/utdid2/core/persistent/b$b;",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 135
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    sput-object v0, Lcom/ta/utdid2/core/persistent/d$a;->f:Ljava/lang/Object;

    return-void
.end method

.method constructor <init>(Ljava/io/File;Ljava/util/Map;)V
    .locals 2

    .prologue
    const/4 v1, 0x0

    .line 138
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 134
    iput-boolean v1, p0, Lcom/ta/utdid2/core/persistent/d$a;->b:Z

    .line 139
    iput-object p1, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    .line 140
    invoke-static {p1}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/io/File;)Ljava/io/File;

    move-result-object v0

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->d:Ljava/io/File;

    .line 141
    iput v1, p0, Lcom/ta/utdid2/core/persistent/d$a;->e:I

    .line 142
    if-eqz p2, :cond_0

    :goto_0
    iput-object p2, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    .line 143
    new-instance v0, Ljava/util/WeakHashMap;

    invoke-direct {v0}, Ljava/util/WeakHashMap;-><init>()V

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->g:Ljava/util/WeakHashMap;

    .line 144
    return-void

    .line 142
    :cond_0
    new-instance p2, Ljava/util/HashMap;

    invoke-direct {p2}, Ljava/util/HashMap;-><init>()V

    goto :goto_0
.end method

.method private static a(Ljava/io/File;)Ljava/io/FileOutputStream;
    .locals 2

    .prologue
    const/4 v1, 0x0

    .line 355
    .line 357
    :try_start_0
    new-instance v0, Ljava/io/FileOutputStream;

    invoke-direct {v0, p0}, Ljava/io/FileOutputStream;-><init>(Ljava/io/File;)V
    :try_end_0
    .catch Ljava/io/FileNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    .line 368
    :goto_0
    return-object v0

    .line 359
    :catch_0
    move-exception v0

    invoke-virtual {p0}, Ljava/io/File;->getParentFile()Ljava/io/File;

    move-result-object v0

    .line 360
    invoke-virtual {v0}, Ljava/io/File;->mkdir()Z

    move-result v0

    if-nez v0, :cond_0

    move-object v0, v1

    .line 361
    goto :goto_0

    .line 364
    :cond_0
    :try_start_1
    new-instance v0, Ljava/io/FileOutputStream;

    invoke-direct {v0, p0}, Ljava/io/FileOutputStream;-><init>(Ljava/io/File;)V
    :try_end_1
    .catch Ljava/io/FileNotFoundException; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_0

    :catch_1
    move-exception v0

    move-object v0, v1

    goto :goto_0
.end method

.method static synthetic a(Lcom/ta/utdid2/core/persistent/d$a;)Ljava/util/WeakHashMap;
    .locals 1

    .prologue
    .line 136
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->g:Ljava/util/WeakHashMap;

    return-object v0
.end method

.method private a(Ljava/util/Map;)V
    .locals 1

    .prologue
    .line 169
    if-eqz p1, :cond_0

    .line 170
    monitor-enter p0

    .line 171
    :try_start_0
    iput-object p1, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    .line 170
    monitor-exit p0

    .line 174
    :cond_0
    return-void

    .line 170
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method static synthetic b(Lcom/ta/utdid2/core/persistent/d$a;)Ljava/util/Map;
    .locals 1

    .prologue
    .line 133
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    return-object v0
.end method

.method static synthetic c(Lcom/ta/utdid2/core/persistent/d$a;)Z
    .locals 1

    .prologue
    .line 371
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/d$a;->f()Z

    move-result v0

    return v0
.end method

.method private e()V
    .locals 1

    .prologue
    .line 157
    monitor-enter p0

    .line 158
    const/4 v0, 0x1

    :try_start_0
    iput-boolean v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->b:Z

    .line 157
    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method private f()Z
    .locals 7

    .prologue
    const/4 v1, 0x1

    const/4 v0, 0x0

    .line 374
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    invoke-virtual {v2}, Ljava/io/File;->exists()Z

    move-result v2

    if-eqz v2, :cond_2

    .line 375
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/d$a;->d:Ljava/io/File;

    invoke-virtual {v2}, Ljava/io/File;->exists()Z

    move-result v2

    if-nez v2, :cond_1

    .line 376
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/d$a;->d:Ljava/io/File;

    invoke-virtual {v2, v3}, Ljava/io/File;->renameTo(Ljava/io/File;)Z

    move-result v2

    if-nez v2, :cond_2

    .line 410
    :cond_0
    :goto_0
    return v0

    .line 380
    :cond_1
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    invoke-virtual {v2}, Ljava/io/File;->delete()Z

    .line 390
    :cond_2
    :try_start_0
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    invoke-static {v2}, Lcom/ta/utdid2/core/persistent/d$a;->a(Ljava/io/File;)Ljava/io/FileOutputStream;

    move-result-object v2

    .line 391
    if-eqz v2, :cond_0

    .line 394
    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    .line 1153
    new-instance v4, Lcom/ta/utdid2/core/persistent/a;

    invoke-direct {v4}, Lcom/ta/utdid2/core/persistent/a;-><init>()V

    .line 1154
    const-string v5, "utf-8"

    invoke-interface {v4, v2, v5}, Lorg/xmlpull/v1/XmlSerializer;->setOutput(Ljava/io/OutputStream;Ljava/lang/String;)V

    .line 1155
    const/4 v5, 0x0

    const/4 v6, 0x1

    invoke-static {v6}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v6

    invoke-interface {v4, v5, v6}, Lorg/xmlpull/v1/XmlSerializer;->startDocument(Ljava/lang/String;Ljava/lang/Boolean;)V

    .line 1157
    const-string v5, "http://xmlpull.org/v1/doc/features.html#indent-output"

    const/4 v6, 0x1

    .line 1156
    invoke-interface {v4, v5, v6}, Lorg/xmlpull/v1/XmlSerializer;->setFeature(Ljava/lang/String;Z)V

    .line 1158
    const/4 v5, 0x0

    invoke-static {v3, v5, v4}, Lcom/ta/utdid2/core/persistent/e;->a(Ljava/util/Map;Ljava/lang/String;Lorg/xmlpull/v1/XmlSerializer;)V

    .line 1159
    invoke-interface {v4}, Lorg/xmlpull/v1/XmlSerializer;->endDocument()V

    .line 395
    invoke-virtual {v2}, Ljava/io/FileOutputStream;->close()V

    .line 398
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/d$a;->d:Ljava/io/File;

    invoke-virtual {v2}, Ljava/io/File;->delete()Z
    :try_end_0
    .catch Lorg/xmlpull/v1/XmlPullParserException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0

    move v0, v1

    .line 399
    goto :goto_0

    :catch_0
    move-exception v1

    .line 404
    :goto_1
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 405
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    invoke-virtual {v1}, Ljava/io/File;->delete()Z

    goto :goto_0

    .line 400
    :catch_1
    move-exception v1

    goto :goto_1
.end method


# virtual methods
.method public final a(Ljava/lang/String;)I
    .locals 1

    .prologue
    .line 205
    monitor-enter p0

    .line 206
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    .line 207
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    :goto_0
    monitor-exit p0

    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0

    .line 205
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 198
    monitor-enter p0

    .line 199
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 200
    if-eqz v0, :cond_0

    :goto_0
    monitor-exit p0

    return-object v0

    :cond_0
    move-object v0, p2

    goto :goto_0

    .line 198
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Lcom/ta/utdid2/core/persistent/b$b;)V
    .locals 2

    .prologue
    .line 178
    monitor-enter p0

    .line 179
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->g:Ljava/util/WeakHashMap;

    sget-object v1, Lcom/ta/utdid2/core/persistent/d$a;->f:Ljava/lang/Object;

    invoke-virtual {v0, p1, v1}, Ljava/util/WeakHashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 178
    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a()Z
    .locals 2

    .prologue
    .line 147
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    if-eqz v0, :cond_0

    .line 148
    new-instance v0, Ljava/io/File;

    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/d$a;->c:Ljava/io/File;

    invoke-virtual {v1}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 149
    invoke-virtual {v0}, Ljava/io/File;->exists()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 150
    const/4 v0, 0x1

    .line 153
    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public final b(Ljava/lang/String;)J
    .locals 2

    .prologue
    .line 212
    monitor-enter p0

    .line 213
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Long;

    .line 214
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v0

    :goto_0
    monitor-exit p0

    return-wide v0

    :cond_0
    const-wide/16 v0, 0x0

    goto :goto_0

    .line 212
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final b()Ljava/util/Map;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "*>;"
        }
    .end annotation

    .prologue
    .line 191
    monitor-enter p0

    .line 193
    :try_start_0
    new-instance v0, Ljava/util/HashMap;

    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    invoke-direct {v0, v1}, Ljava/util/HashMap;-><init>(Ljava/util/Map;)V

    monitor-exit p0

    return-object v0

    .line 191
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final b(Lcom/ta/utdid2/core/persistent/b$b;)V
    .locals 1

    .prologue
    .line 185
    monitor-enter p0

    .line 186
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->g:Ljava/util/WeakHashMap;

    invoke-virtual {v0, p1}, Ljava/util/WeakHashMap;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 185
    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final c(Ljava/lang/String;)F
    .locals 1

    .prologue
    .line 219
    monitor-enter p0

    .line 220
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Float;

    .line 221
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v0

    :goto_0
    monitor-exit p0

    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0

    .line 219
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final c()Lcom/ta/utdid2/core/persistent/b$a;
    .locals 1

    .prologue
    .line 351
    new-instance v0, Lcom/ta/utdid2/core/persistent/d$a$a;

    invoke-direct {v0, p0}, Lcom/ta/utdid2/core/persistent/d$a$a;-><init>(Lcom/ta/utdid2/core/persistent/d$a;)V

    return-object v0
.end method

.method public final d()Z
    .locals 1

    .prologue
    .line 163
    monitor-enter p0

    .line 164
    :try_start_0
    iget-boolean v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->b:Z

    monitor-exit p0

    return v0

    .line 163
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final d(Ljava/lang/String;)Z
    .locals 1

    .prologue
    .line 226
    monitor-enter p0

    .line 227
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Boolean;

    .line 228
    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    :goto_0
    monitor-exit p0

    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0

    .line 226
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final e(Ljava/lang/String;)Z
    .locals 1

    .prologue
    .line 233
    monitor-enter p0

    .line 234
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a;->a:Ljava/util/Map;

    invoke-interface {v0, p1}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    monitor-exit p0

    return v0

    .line 233
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method
