.class public final Lcom/ta/utdid2/core/persistent/d$a$a;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/ta/utdid2/core/persistent/b$a;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/ta/utdid2/core/persistent/d$a;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x11
    name = "a"
.end annotation


# instance fields
.field final synthetic a:Lcom/ta/utdid2/core/persistent/d$a;

.field private final b:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation
.end field

.field private c:Z


# direct methods
.method public constructor <init>(Lcom/ta/utdid2/core/persistent/d$a;)V
    .locals 1

    .prologue
    .line 238
    iput-object p1, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 239
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    .line 240
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->c:Z

    return-void
.end method


# virtual methods
.method public final a()Lcom/ta/utdid2/core/persistent/b$a;
    .locals 1

    .prologue
    .line 285
    monitor-enter p0

    .line 286
    const/4 v0, 0x1

    :try_start_0
    iput-boolean v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->c:Z

    .line 287
    monitor-exit p0

    return-object p0

    .line 285
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b$a;
    .locals 1

    .prologue
    .line 278
    monitor-enter p0

    .line 279
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-interface {v0, p1, p0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 280
    monitor-exit p0

    return-object p0

    .line 278
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Ljava/lang/String;F)Lcom/ta/utdid2/core/persistent/b$a;
    .locals 2

    .prologue
    .line 264
    monitor-enter p0

    .line 265
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-static {p2}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 266
    monitor-exit p0

    return-object p0

    .line 264
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Ljava/lang/String;I)Lcom/ta/utdid2/core/persistent/b$a;
    .locals 2

    .prologue
    .line 250
    monitor-enter p0

    .line 251
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-static {p2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 252
    monitor-exit p0

    return-object p0

    .line 250
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Ljava/lang/String;J)Lcom/ta/utdid2/core/persistent/b$a;
    .locals 2

    .prologue
    .line 257
    monitor-enter p0

    .line 258
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-static {p2, p3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 259
    monitor-exit p0

    return-object p0

    .line 257
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Ljava/lang/String;Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b$a;
    .locals 1

    .prologue
    .line 243
    monitor-enter p0

    .line 244
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-interface {v0, p1, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 245
    monitor-exit p0

    return-object p0

    .line 243
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final a(Ljava/lang/String;Z)Lcom/ta/utdid2/core/persistent/b$a;
    .locals 2

    .prologue
    .line 271
    monitor-enter p0

    .line 272
    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-static {p2}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 273
    monitor-exit p0

    return-object p0

    .line 271
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public final b()Z
    .locals 8

    .prologue
    const/4 v0, 0x0

    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 295
    .line 298
    invoke-static {}, Lcom/ta/utdid2/core/persistent/d;->a()Ljava/lang/Object;

    move-result-object v5

    monitor-enter v5

    .line 299
    :try_start_0
    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    invoke-static {v3}, Lcom/ta/utdid2/core/persistent/d$a;->a(Lcom/ta/utdid2/core/persistent/d$a;)Ljava/util/WeakHashMap;

    move-result-object v3

    invoke-virtual {v3}, Ljava/util/WeakHashMap;->size()I

    move-result v3

    if-lez v3, :cond_4

    move v4, v1

    .line 300
    :goto_0
    if-eqz v4, :cond_9

    .line 301
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 302
    new-instance v0, Ljava/util/HashSet;

    .line 303
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    invoke-static {v2}, Lcom/ta/utdid2/core/persistent/d$a;->a(Lcom/ta/utdid2/core/persistent/d$a;)Ljava/util/WeakHashMap;

    move-result-object v2

    invoke-virtual {v2}, Ljava/util/WeakHashMap;->keySet()Ljava/util/Set;

    move-result-object v2

    .line 302
    invoke-direct {v0, v2}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    move-object v2, v0

    move-object v3, v1

    .line 306
    :goto_1
    monitor-enter p0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    .line 307
    :try_start_1
    iget-boolean v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->c:Z

    if-eqz v0, :cond_0

    .line 308
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    invoke-static {v0}, Lcom/ta/utdid2/core/persistent/d$a;->b(Lcom/ta/utdid2/core/persistent/d$a;)Ljava/util/Map;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Map;->clear()V

    .line 309
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->c:Z

    .line 312
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v6

    :cond_1
    :goto_2
    invoke-interface {v6}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-nez v0, :cond_5

    .line 326
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->b:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->clear()V

    .line 306
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 328
    :try_start_2
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    invoke-static {v0}, Lcom/ta/utdid2/core/persistent/d$a;->c(Lcom/ta/utdid2/core/persistent/d$a;)Z

    move-result v1

    .line 329
    if-eqz v1, :cond_2

    .line 330
    iget-object v6, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    .line 1157
    monitor-enter v6
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_1

    .line 1158
    const/4 v0, 0x1

    :try_start_3
    iput-boolean v0, v6, Lcom/ta/utdid2/core/persistent/d$a;->b:Z

    .line 1157
    monitor-exit v6
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_2

    .line 298
    :cond_2
    :try_start_4
    monitor-exit v5
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_1

    .line 334
    if-eqz v4, :cond_3

    .line 335
    invoke-interface {v3}, Ljava/util/List;->size()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    :goto_3
    if-gez v0, :cond_7

    .line 346
    :cond_3
    return v1

    :cond_4
    move v4, v2

    .line 299
    goto :goto_0

    .line 312
    :cond_5
    :try_start_5
    invoke-interface {v6}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 313
    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 314
    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v0

    .line 315
    if-ne v0, p0, :cond_6

    .line 316
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    invoke-static {v0}, Lcom/ta/utdid2/core/persistent/d$a;->b(Lcom/ta/utdid2/core/persistent/d$a;)Ljava/util/Map;

    move-result-object v0

    invoke-interface {v0, v1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    .line 321
    :goto_4
    if-eqz v4, :cond_1

    .line 322
    invoke-interface {v3, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_2

    .line 306
    :catchall_0
    move-exception v0

    monitor-exit p0
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    :try_start_6
    throw v0

    .line 298
    :catchall_1
    move-exception v0

    monitor-exit v5
    :try_end_6
    .catchall {:try_start_6 .. :try_end_6} :catchall_1

    throw v0

    .line 318
    :cond_6
    :try_start_7
    iget-object v7, p0, Lcom/ta/utdid2/core/persistent/d$a$a;->a:Lcom/ta/utdid2/core/persistent/d$a;

    invoke-static {v7}, Lcom/ta/utdid2/core/persistent/d$a;->b(Lcom/ta/utdid2/core/persistent/d$a;)Ljava/util/Map;

    move-result-object v7

    invoke-interface {v7, v1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_7
    .catchall {:try_start_7 .. :try_end_7} :catchall_0

    goto :goto_4

    .line 1157
    :catchall_2
    move-exception v0

    :try_start_8
    monitor-exit v6
    :try_end_8
    .catchall {:try_start_8 .. :try_end_8} :catchall_2

    :try_start_9
    throw v0
    :try_end_9
    .catchall {:try_start_9 .. :try_end_9} :catchall_1

    .line 336
    :cond_7
    invoke-interface {v3, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    .line 337
    invoke-interface {v2}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v4

    :goto_5
    invoke-interface {v4}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-nez v5, :cond_8

    .line 335
    add-int/lit8 v0, v0, -0x1

    goto :goto_3

    .line 337
    :cond_8
    invoke-interface {v4}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    goto :goto_5

    :cond_9
    move-object v2, v0

    move-object v3, v0

    goto/16 :goto_1
.end method
